using MeLevaAi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MeLevaAi.Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    public DbSet<Passageiro> Passageiros { get; set; }
    public DbSet<Motorista> Motoristas => Set<Motorista>();
    public DbSet<Corrida> Corridas { get; set; }
    public DbSet<Veiculo> Veiculos => Set<Veiculo>();
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Passageiro>()
            .HasMany(p => p.Corridas)
            .WithOne(c => c.Passageiro)
            .HasForeignKey(e => e.PassageiroId)
            .HasPrincipalKey(e => e.Id);
        
    }
    
}