using MeLevaAi.Domain.Contracts.Requests.Passageiro;
using MeLevaAi.Domain.Contracts.Responses.Passageiro;

namespace MeLevaAi.Application.Contracts;

public interface IPassageiroService
{
    public PassageiroResponse? Obter(Guid id);
    public Task<PassageiroResponse> Cadastrar(CadastrarPassageiroRequest request);
    public AdicionarSaldoResponse AdicionarSaldo(AdicionarSaldoRequest request, Guid id);
    public List<ListarPassageiroResponse> ListarHabilitados();

    public List<ListarPassageiroResponse> ListarPassageiros();
    public string? ValidarPassageiro(CadastrarPassageiroRequest request);
}