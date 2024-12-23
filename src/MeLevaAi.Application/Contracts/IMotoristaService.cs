using MeLevaAi.Domain.Contracts.Requests.Motorista;
using MeLevaAi.Domain.Contracts.Responses.Motorista;

namespace MeLevaAi.Application.Contracts;

public interface IMotoristaService
{
    public IEnumerable<MotoristaResponse> Listar();
    public MotoristaResponse? Obter(Guid id);
    public MotoristaResponse Cadastrar(CadastrarMoristaRequest request);
    public MotoristaResponse Delete(Guid id);
}