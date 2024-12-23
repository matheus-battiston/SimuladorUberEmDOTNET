using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Guid;

namespace MeLevaAi.Domain.Models;
[Table("Passageiros")]
public class Passageiro
{
    public Passageiro(string nome, DateOnly dataNascimento, string cpf)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Cpf = cpf;
        Corridas = new List<Corrida>();
    }

    public Guid Id { get; init; } = NewGuid();

    [Required]
    public string Nome { get; private set; }
    
    [Required]
    public DateOnly DataNascimento { get; private set; }
    
    [Required]
    public string Cpf { get; private set; }
    public float SaldoEmConta { get; private set; }
    public int QuantidadeAvaliacoes { get; private set; }
    public int SomaDasNotas { get; private set; }
    public double MediaDasAvaliacoes { get; private set; } = 5;
    public int NumeroDeCorridas { get; private set; }
    public bool Disponivel { get; private set; } = true;

    public List<Corrida> Corridas { get; set; }

    public void AdicionarSaldo(float valor)
    {
        SaldoEmConta += valor;
    }

    public void Indisponivel()
    {
        Disponivel = false;
    }

    public void RealizarPagamento(float valor)
    {
        SaldoEmConta -= valor;
    }

    public void TornarDisponivel()
    {
        Disponivel = true;
    }
}