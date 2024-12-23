using MeLevaAi.Domain.Models;

namespace MeLevaAi.Domain.Contracts.Repositories;

public interface IVeiculoRepository
{
    public IEnumerable<Veiculo> Listar();
    public Veiculo? Obter(Guid id);
    public Task Cadastrar(Veiculo id);
}