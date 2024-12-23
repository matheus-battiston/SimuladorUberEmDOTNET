using MeLevaAi.Domain.Contracts.Repositories;
using MeLevaAi.Domain.Models;
using MeLevaAi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MeLevaAi.Infrastructure.Repositories;

public class CorridaRepository : ICorridaRepository
{
    private readonly DataContext _context;

    public CorridaRepository(DataContext context)
    {
        _context = context;
    }


    public IEnumerable<Corrida> Listar()
        => _context.Corridas;
    
    public int Tamanho()
        => _context.Corridas.Count();
    
    public Corrida? Obter(Guid id)
        => _context.Corridas
            .Include(c => c.Passageiro)
            .Include(c => c.Motorista)
            .FirstOrDefault(c => c.Id == id);
    
    public async Task Adicionar(Corrida novaCorrida)
    {
        _context.Corridas.Add(novaCorrida);
        await _context.SaveChangesAsync();    }

    public async Task Alterar(Corrida corrida)
    {
        _context.Corridas.Entry(corrida);
        await _context.SaveChangesAsync();
    }
}