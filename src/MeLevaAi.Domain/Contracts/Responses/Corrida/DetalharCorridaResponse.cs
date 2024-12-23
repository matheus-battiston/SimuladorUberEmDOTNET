using MeLevaAi.Domain.Contracts.Responses.Motorista;
using MeLevaAi.Domain.Contracts.Responses.Passageiro;

namespace MeLevaAi.Domain.Contracts.Responses.Corrida;

public class DetalharCorridaResponse
{
    public DetalharCorridaResponse(Guid id, double latitudeInicio, double longitudeInicio, double latitudeFinal, double longitudeFinal, DateTime? horarioInicio, DateTime? horarioChegada, string status, double? valorEstimado, double? valorTotal, int? notaMotorista, int? notaPassageiro, MotoristaResponse motorista, PassageiroResponse passageiro, double distancia)
    {
        Id = id;
        LatitudeInicio = latitudeInicio;
        LongitudeInicio = longitudeInicio;
        LatitudeFinal = latitudeFinal;
        LongitudeFinal = longitudeFinal;
        HorarioInicio = horarioInicio;
        HorarioChegada = horarioChegada;
        Status = status;
        ValorEstimado = valorEstimado;
        ValorTotal = valorTotal;
        NotaMotorista = notaMotorista;
        NotaPassageiro = notaPassageiro;
        Motorista = motorista;
        Passageiro = passageiro;
        Distancia = distancia;
    }

    public DetalharCorridaResponse()
    {
    }
    public Guid Id { get; init; }
    public double LatitudeInicio { get; set; }
    public double LongitudeInicio { get; set; }
    public double LatitudeFinal { get; set; }
    public double LongitudeFinal { get; set; }
    public DateTime? HorarioInicio { get; set; }
    public DateTime? HorarioChegada { get; set; }
    public string Status { get; set; }
    public double? ValorEstimado { get; set; }
    public double? ValorTotal { get; set; }
    public int? NotaMotorista { get; set; }
    public int? NotaPassageiro { get; set; }
    public MotoristaResponse Motorista { get; set; }
    public PassageiroResponse Passageiro { get; set; }
    public double Distancia { get; set; }
}