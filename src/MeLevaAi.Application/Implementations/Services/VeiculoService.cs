using MeLevaAi.Application.Contracts;
using MeLevaAi.Application.Implementations.Mappers;
using MeLevaAi.Domain.Contracts.Repositories;
using MeLevaAi.Domain.Contracts.Requests.Veiculo;
using MeLevaAi.Domain.Contracts.Responses.Veiculo;
using MeLevaAi.Domain.Models;
using MeLevaAi.Domain.Validations;

namespace MeLevaAi.Application.Implementations.Services;

public class VeiculoService : IVeiculoService
{
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IMotoristaRepository _motoristaRepository;


    public VeiculoService(IVeiculoRepository veiculoRepository, IMotoristaRepository motoristaRepository)
    {
        _veiculoRepository = veiculoRepository;
        _motoristaRepository = motoristaRepository;
    }

    public IEnumerable<VeiculoResponse> Listar() =>
        _veiculoRepository.Listar().Select(veiculo => veiculo.ToVeiculoResponse());
    
    public VeiculoResponse? Obter(Guid id)
        => _veiculoRepository.Obter(id)?.ToVeiculoResponse();

    public VeiculoResponse Cadastrar(CadastrarVeiculoRequest request)
    {
        var response = new VeiculoResponse();

        var motorista = _motoristaRepository.Obter(request.ProprietarioId);

        if(motorista is null)
        {
            response.AddNotification(new Notification("Motorista não encontrado"));
            return response;
        }
        motorista.Disponivel = true;

        if((Categoria)request.Categoria != motorista.HabilitacaoCategoria)
        {
            response.AddNotification(new Notification("Motorista com categoria diferente que a do veiculo"));
            return response;
        }

        var veiculo = request.ToVeiculo();
        motorista.AdicionarVeiculo(veiculo);
        
        _veiculoRepository.Cadastrar(veiculo);
        _motoristaRepository.Alterar(motorista);

        return veiculo.ToVeiculoResponse();
    }
}