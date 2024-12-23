using MeLevaAi.Application.Contracts;
using MeLevaAi.Application.Implementations.Mappers;
using MeLevaAi.Domain.Contracts.Repositories;
using MeLevaAi.Domain.Contracts.Requests.Motorista;
using MeLevaAi.Domain.Contracts.Responses.Motorista;
using MeLevaAi.Domain.Validations;
using MeLevaAi.Domain.Validations.Passageiro;

namespace MeLevaAi.Application.Implementations.Services;

public class MotoristaService : IMotoristaService
{
    
    private readonly IMotoristaRepository _motoristaRepository;

    public MotoristaService(IMotoristaRepository motoristaRepository)
    {
        _motoristaRepository = motoristaRepository;
    }

    public IEnumerable<MotoristaResponse> Listar()
        => _motoristaRepository.Listar().Select(motorista => motorista.ToMotoristaResponse());

    public MotoristaResponse? Obter(Guid id)
        => _motoristaRepository.Obter(id)?.ToMotoristaResponse();

    public MotoristaResponse Cadastrar(CadastrarMoristaRequest request)
    {

        var response = new MotoristaResponse();

        var anoAtual = DateTime.Now.Year;

        if (anoAtual - request.DataNascimento.Year < 18)
        {
            response.AddNotification(new Notification("Idade minima 18 anos"));
            return response;
        }

        if (!CpfValido.ValidaCPF(request.CPF))
        {
            response.AddNotification(new Notification("CPF invalido"));
            return response;
        }

        if (request.HabilitacaoDataVencimento.Year <= anoAtual)
        {
            response.AddNotification(new Notification("Carteira de habilitação vencida"));
            return response;
        }

        if(_motoristaRepository.ObterPorCPF(request.CPF))
        {
            response.AddNotification(new Notification("Motorista já cadastrado"));
            return response;
        }

        var motorista = request.ToMotorista();

        _motoristaRepository.Cadastrar(motorista);

        return motorista.ToMotoristaResponse();
    }

    public MotoristaResponse Delete(Guid id)
    {
        var response = new MotoristaResponse();

        var motorista = _motoristaRepository.Obter(id);
        
        if(motorista is null)
        {
            response.AddNotification(new Notification("Motorista não existe"));
            return response;
        }
        
        if(motorista.Veiculo is not null)
        {
            response.AddNotification(new Notification("Motorista está vinculado a um veiculo"));
            return response;
        }

        _motoristaRepository.Delete(motorista);

        return response;
    }
}