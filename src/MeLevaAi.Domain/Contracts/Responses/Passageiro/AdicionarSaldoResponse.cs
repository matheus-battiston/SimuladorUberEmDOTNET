using MeLevaAi.Domain.Validations;

namespace MeLevaAi.Domain.Contracts.Responses.Passageiro;

public class AdicionarSaldoResponse : Notifiable
{

    public string Nome { get; set; }
    public Guid Id { get; set; }
    public double NovoSaldo { get; set; }
}