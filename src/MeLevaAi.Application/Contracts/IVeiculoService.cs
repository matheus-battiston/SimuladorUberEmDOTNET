using MeLevaAi.Domain.Contracts.Requests.Veiculo;
using MeLevaAi.Domain.Contracts.Responses.Veiculo;

namespace MeLevaAi.Application.Contracts;

public interface IVeiculoService
{
    public IEnumerable<VeiculoResponse> Listar();
    public VeiculoResponse? Obter(Guid id);
    public VeiculoResponse Cadastrar(CadastrarVeiculoRequest request);
    

}