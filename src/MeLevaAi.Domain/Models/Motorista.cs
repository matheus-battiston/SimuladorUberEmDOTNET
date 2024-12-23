using System.ComponentModel.DataAnnotations.Schema;

namespace MeLevaAi.Domain.Models;

using static Guid;

public class Motorista
{
    public Motorista(string nome, DateTime dataNascimento, string cpf, string habilitacaoNumero, DateOnly habilitacaoDataVencimento, Categoria habilitacaoCategoria)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = cpf;
        HabilitacaoNumero = habilitacaoNumero;
        HabilitacaoDataVencimento = habilitacaoDataVencimento;
        HabilitacaoCategoria = habilitacaoCategoria;
    }

    public Motorista()
    {
        
    }

    public Guid Id { get; init; } = NewGuid();
    public double Saldo { get; set; } = 0;
    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string CPF { get; private set; }
    public string HabilitacaoNumero { get; set; }
    public DateOnly HabilitacaoDataVencimento { get; set; }
    public Categoria HabilitacaoCategoria { get; set; }
    public bool Disponivel { get; set; }
    public int SomaDasNotas { get; set; }
    public double MediaDasNotas { get; set; }
    public int NumeroDeCorridas { get; set; } = 0;
    public int QuantidadeDeAvaliacoes { get; set; } = 0;

    public ICollection<Corrida> Corridas { get; set; } = new List<Corrida>();
    public Veiculo? Veiculo { get; set; }
    
    [ForeignKey("Veiculo")]
    public Guid? VeiculoId { get; set; }

    public void AdicionarVeiculo(Veiculo veiculo)
    {
        VeiculoId = veiculo.Id;
    }

    public void Receber(float valorCorrida)
    {
        Saldo += valorCorrida;
    }
}
