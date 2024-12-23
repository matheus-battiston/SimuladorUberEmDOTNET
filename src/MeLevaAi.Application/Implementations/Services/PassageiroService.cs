using MeLevaAi.Application.Contracts;
using MeLevaAi.Application.Implementations.Mappers;
using MeLevaAi.Domain.Contracts.Repositories;
using MeLevaAi.Domain.Contracts.Requests.Passageiro;
using MeLevaAi.Domain.Contracts.Responses.Passageiro;
using MeLevaAi.Domain.Validations;
using MeLevaAi.Domain.Validations.Passageiro;
using static MeLevaAi.Application.Implementations.Mappers.PassageiroMapper;

namespace MeLevaAi.Application.Implementations.Services;

public class PassageiroService : IPassageiroService
{
    private const string CpfInvalido = "CPF invalido";
    private const string CpfUtilizado = "CPF ja foi cadastrado anteriormente";
    private const string IdadeMinimaNaoAtingida = "O passageiro nao tem a idade minima de 16 anos";
    private const string SaldoDeveSerMaiorQueZero = "O saldo adicionado deve ser maior que 0";
    private const string PassageiroNaoExiste = "O passageiro informado nao existe";

    private readonly IPassageiroRepository _passageiroRepository;

    public PassageiroService(IPassageiroRepository passageiroRepository)
    {
        _passageiroRepository = passageiroRepository;
    }
   
    public PassageiroResponse? Obter(Guid id)
    {
        var passageiro = _passageiroRepository.Obter(id);
        
        if (passageiro is not null)
        {
            var response = ToResponse(passageiro);
            return response;
        }

        return null;
    }

    public async Task<PassageiroResponse> Cadastrar(CadastrarPassageiroRequest request)
    {
        var response = new PassageiroResponse();
        var validacao = ValidarPassageiro(request);
        if (validacao is not null)
        {
            response.AddNotification(new Notification(validacao));
            return response;
        }
        var novoPassageiro = request.ToEntity();
        await _passageiroRepository.Cadastrar(novoPassageiro);
        return ToResponse(novoPassageiro);
    }

    public AdicionarSaldoResponse AdicionarSaldo(AdicionarSaldoRequest request, Guid id)
    {
        var response = new AdicionarSaldoResponse();

        if (request.ValorDeposito <= 0)
        {
            response.AddNotification(new Notification(SaldoDeveSerMaiorQueZero));
            return response;
        }

        var passageiro = _passageiroRepository.Obter(id);
        if (passageiro is null)
        {
            response.AddNotification(new Notification(PassageiroNaoExiste));
            return response;
        }

        passageiro.AdicionarSaldo(request.ValorDeposito);

        _passageiroRepository.Alterar(passageiro);
        
        response.NovoSaldo = passageiro.SaldoEmConta;
        response.Nome = passageiro.Nome;
        response.Id = passageiro.Id;

        return response;
    }

    public List<ListarPassageiroResponse> ListarHabilitados()
    {
        var passageiros = _passageiroRepository.Habilitados().ToList();
        return passageiros.Select(ListarResponse).ToList();
    }

    public List<ListarPassageiroResponse> ListarPassageiros()
    {
        var passageiros = _passageiroRepository.Listar().ToList();
        return passageiros.Select((ListarResponse)).ToList();
    }

    public string? ValidarPassageiro(CadastrarPassageiroRequest request)
    {
        if (!CpfValido.ValidaCPF(request.Cpf))
        {
            return CpfInvalido;
        }

        if (_passageiroRepository.ExisteCpf(request.Cpf))
        {
            return CpfUtilizado;
        }

        if (IdadePassageiro.Validar(request.DataNascimento) is false)
        {
            return IdadeMinimaNaoAtingida;
        }

        return null;
    }

}