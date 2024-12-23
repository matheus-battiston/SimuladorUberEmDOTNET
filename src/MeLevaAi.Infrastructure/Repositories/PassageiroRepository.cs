using MeLevaAi.Domain.Contracts.Repositories;
using MeLevaAi.Domain.Models;
using MeLevaAi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MeLevaAi.Infrastructure.Repositories;

public class PassageiroRepository : IPassageiroRepository
{
    private readonly DataContext _context;

    public PassageiroRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Passageiro> Listar() => _context.Passageiros;

    public Passageiro? Obter(Guid id)
        => _context.Passageiros
            .Include(m => m.Corridas)
                .ThenInclude(c => c.Motorista)
            .FirstOrDefault(p => p.Id == id);

    public async Task<Passageiro> Cadastrar(Passageiro passageiro)
    {
        _context.Passageiros.Add(passageiro);
        await _context.SaveChangesAsync();
        return passageiro;
    }

    public async Task<bool> Remover(Guid id)
    {
        var passageiro = _context.Passageiros.Find(id);
        if (passageiro != null)
        {
            _context.Passageiros.Remove(passageiro);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public bool ExisteCpf(string cpf)
    {
        var passageiroBuscado = _context.Passageiros.Any(p => p.Cpf == cpf);

        return passageiroBuscado;
    }

    public async Task Alterar(Passageiro passageiro)
    {
        _context.Entry(passageiro);
        await _context.SaveChangesAsync();
        
    }

    public List<Passageiro> Habilitados()
    {
        return _context.Passageiros.Where(p => p.Disponivel).ToList();
    }
}