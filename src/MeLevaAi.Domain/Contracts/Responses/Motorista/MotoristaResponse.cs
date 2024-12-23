using MeLevaAi.Domain.Contracts.Responses.Corrida;
using MeLevaAi.Domain.Contracts.Responses.Veiculo;
using MeLevaAi.Domain.Validations;

namespace MeLevaAi.Domain.Contracts.Responses.Motorista;

public class MotoristaResponse : Notifiable
{
    public MotoristaResponse(Guid id, string nome, string status, double nota, int numeroDeCorridas, double saldoEmConta, string habilitacaoNumero, DateOnly habilitacaoDataVnecimento, string habilitacaoCategoria, VeiculoResponse? veiculo, List<CorridaResponse> corridas, string email, DateTime dataNascimento, string cpf)
    {
        Id = id;
        Nome = nome;
        Status = status;
        Nota = nota;
        NumeroDeCorridas = numeroDeCorridas;
        SaldoEmConta = saldoEmConta;
        HabilitacaoNumero = habilitacaoNumero;
        HabilitacaoDataVencimento = habilitacaoDataVnecimento;
        HabilitacaoCategoria = habilitacaoCategoria;
        Veiculo = veiculo;
        Corridas = corridas;
        DataNascimento = dataNascimento;
        CPF = cpf;
    }

    public MotoristaResponse() { }

    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Status  { get; set; }
    public double Nota { get; set; }
    public int NumeroDeCorridas { get; set; }
    public double SaldoEmConta { get; set; }
    public string  HabilitacaoNumero { get; set; }
    public DateOnly HabilitacaoDataVencimento { get; set; }
    public string HabilitacaoCategoria { get; set; }
    public VeiculoResponse? Veiculo { get; set; }
    public List<CorridaResponse>? Corridas { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
}