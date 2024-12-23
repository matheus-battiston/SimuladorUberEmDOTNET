using MeLevaAi.Domain.Contracts.Repositories;
using MeLevaAi.Domain.Models;
using MeLevaAi.Infrastructure.Data;

namespace MeLevaAi.Infrastructure.Repositories;

public class VeiculoRepository : IVeiculoRepository
{
    private readonly DataContext _context;

    public VeiculoRepository(DataContext context)
    {
        _context = context;
    }


    public IEnumerable<Veiculo> Listar() =>
        _context.Veiculos;

    public Veiculo? Obter(Guid id) =>
     _context.Veiculos.Find(id);

    public async Task Cadastrar(Veiculo veiculo)
    {
        _context.Veiculos.Add(veiculo);
        await _context.SaveChangesAsync();

    }
}