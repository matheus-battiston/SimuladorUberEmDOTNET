using MeLevaAi.Domain.Models;

namespace MeLevaAi.Domain.Contracts.Repositories;

public interface IMotoristaRepository
{
    public IEnumerable<Motorista> Listar();
    public Motorista? Obter(Guid id);
    public bool ObterPorCPF(string cpf);
    public void Cadastrar(Motorista motorista);
    public IEnumerable<Motorista> ObterDisponiveis();
    public void Delete(Motorista motorista);
    public Task Alterar(Motorista motorista);



}