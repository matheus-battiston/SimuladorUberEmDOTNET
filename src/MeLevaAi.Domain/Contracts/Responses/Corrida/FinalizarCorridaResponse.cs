using MeLevaAi.Domain.Validations;

namespace MeLevaAi.Domain.Contracts.Responses.Corrida;

public class FinalizarCorridaResponse : Notifiable
{
    public FinalizarCorridaResponse(DateTime horarioChegada, double valorTotal)
    {
        HorarioChegada = horarioChegada;
        ValorTotal = valorTotal;
    }

    public FinalizarCorridaResponse()
    {
        
    }

    public DateTime HorarioChegada { get; set; }
    public double ValorTotal { get; set; }
}
