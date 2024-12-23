using MeLevaAi.Domain.Models;

namespace MeLevaAi.Domain.Contracts.Repositories;

public interface IPassageiroRepository
{
    public IEnumerable<Passageiro> Listar();
    public Passageiro? Obter(Guid id);
    public Task<Passageiro> Cadastrar(Passageiro passageiro);
    public Task<bool> Remover(Guid id);
    public bool ExisteCpf(string cpf);
    public Task Alterar(Passageiro passageiro);
    public List<Passageiro> Habilitados();
}