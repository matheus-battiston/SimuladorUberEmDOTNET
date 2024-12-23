using MeLevaAi.Domain.Contracts.Requests.Motorista;
using MeLevaAi.Domain.Contracts.Responses.Motorista;
using MeLevaAi.Domain.Models;

namespace MeLevaAi.Application.Implementations.Mappers;

public static class MotoristaMapper
{
    public static Motorista ToMotorista(this CadastrarMoristaRequest request)
        => new(request.Nome, request.DataNascimento, request.CPF, request.HabilitacaoNumero, request.HabilitacaoDataVencimento, (Categoria)request.HabilitacaoCategoria);

    public static MotoristaResponse ToMotoristaResponse(this Motorista motorista)
    {
        var response = new MotoristaResponse
        {
            Id = motorista.Id,
            Nome = motorista.Nome,
            Nota = motorista.MediaDasNotas,
            NumeroDeCorridas = motorista.NumeroDeCorridas,
            SaldoEmConta = motorista.Saldo,
            HabilitacaoNumero = motorista.HabilitacaoNumero,
            HabilitacaoDataVencimento = motorista.HabilitacaoDataVencimento,
            HabilitacaoCategoria = motorista.HabilitacaoCategoria.ToString(),
            Corridas = motorista.Corridas?.Select(c => c.ToCorridaResponse()).ToList(),
            CPF = motorista.CPF,
            DataNascimento = motorista.DataNascimento
            
        };

        if (motorista.Veiculo is not null)
        {
            response.Veiculo = motorista.Veiculo.ToVeiculoResponse();
        }

        return response;
    }
}
