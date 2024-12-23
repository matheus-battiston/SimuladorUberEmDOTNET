using MeLevaAi.Domain.Validations;

namespace MeLevaAi.Domain.Contracts.Responses.Corrida;

public class IniciarCorridaResponse : Notifiable
{
    public double ValorEstimado { get; set; }
    public double TempoEstimado { get; set; }
}