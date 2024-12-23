using MeLevaAi.Domain.Contracts.Requests.Passageiro;
using MeLevaAi.Domain.Contracts.Responses.Passageiro;
using MeLevaAi.Domain.Models;

namespace MeLevaAi.Application.Implementations.Mappers;


public static class PassageiroMapper
{
    public static Passageiro ToEntity(this CadastrarPassageiroRequest request)
        => new(request.Nome, request.DataNascimento, request.Cpf);

    public static PassageiroResponse ToResponse(Passageiro passageiroCadastrado)
    {
        var corridas = passageiroCadastrado.Corridas.Select(c => c.ToCorridaResponse()).ToList();
        return new PassageiroResponse(passageiroCadastrado.Id, 
            passageiroCadastrado.Nome, 
            passageiroCadastrado.MediaDasAvaliacoes,
            passageiroCadastrado.NumeroDeCorridas,
            passageiroCadastrado.SaldoEmConta,
            corridas);
    }

    public static ListarPassageiroResponse ListarResponse(Passageiro passageiro)
    {
        return new ListarPassageiroResponse(passageiro.Id, passageiro.Nome, passageiro.Disponivel, passageiro.MediaDasAvaliacoes);
    }
    
}