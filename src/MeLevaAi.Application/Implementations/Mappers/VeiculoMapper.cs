using MeLevaAi.Domain.Contracts.Requests.Veiculo;
using MeLevaAi.Domain.Contracts.Responses.Veiculo;
using MeLevaAi.Domain.Models;

namespace MeLevaAi.Application.Implementations.Mappers;

public static class VeiculoMapper
{

    public static Veiculo ToVeiculo(this CadastrarVeiculoRequest request) =>
        new(request.Placa, request.Modelo, request.Cor, request.FotoUrl, (Categoria)request.Categoria);
    
    public static VeiculoResponse ToVeiculoResponse(this Veiculo veiculo)
    {
        return new VeiculoResponse(veiculo.Placa, veiculo.Modelo, veiculo.Cor, veiculo.FotoUrl);
    }
}
