using MeLevaAi.Domain.Contracts.Repositories;
using MeLevaAi.Domain.Models;
using MeLevaAi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static System.DateOnly;
using static System.DateTime;

namespace MeLevaAi.Infrastructure.Repositories;

public class MotoristaRepository : IMotoristaRepository
{

    private readonly DataContext _context;

    public MotoristaRepository(DataContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Motorista> Listar()
        => _context.Motoristas;

    // dbContext.Pessoas.Include(p => p.Endereco).FirstOrDefault(p => p.Id == 1);

    public Motorista? Obter(Guid id)
        => _context.Motoristas
            .Include(m => m.Corridas)
            .ThenInclude(c => c.Passageiro)
            .Include(m => m.Veiculo)
            .FirstOrDefault(p => p.Id == id);

    public bool ObterPorCPF(string cpf)
    {
        var motoristaBuscado = _context.Motoristas.Any(m => m.CPF == cpf);
        return motoristaBuscado;
    }
    
    public async void Cadastrar(Motorista motorista)
    {
        _context.Motoristas.Add(motorista);
        await _context.SaveChangesAsync();
    }
    public IEnumerable<Motorista> ObterDisponiveis()
    {
        var dataAtual = FromDateTime(Now);
        return _context.Motoristas
            .Include(m => m.Veiculo)
            .Where(p => p.Disponivel && p.HabilitacaoDataVencimento >= dataAtual);
    }
    
    public void Delete(Motorista motorista)
    {
        _context.Motoristas.Remove(motorista);
    }
    
    public async Task Alterar(Motorista motorista)
    {
        var motoristaExistente = await _context.Motoristas.FindAsync(motorista.Id);
        
        _context.Entry(motoristaExistente).CurrentValues.SetValues(motorista);
        await _context.SaveChangesAsync();
        
    }
}