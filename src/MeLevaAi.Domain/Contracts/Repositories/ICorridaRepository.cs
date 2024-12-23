using MeLevaAi.Domain.Models;

namespace MeLevaAi.Domain.Contracts.Repositories;

public interface ICorridaRepository
{
    public IEnumerable<Corrida> Listar();
    public int Tamanho();
    public Corrida? Obter(Guid id);
    public Task Adicionar(Corrida novaCorrida);

    public Task Alterar(Corrida corrida);
}