using System.ComponentModel.DataAnnotations.Schema;
using static System.Guid;

namespace MeLevaAi.Domain.Models;

using static Double;


public class Corrida
{
    public Corrida()
    {
        
    }
    public Corrida(double latitudeInicio, double longitudeInicio, double latitudeFinal, double longitudeFinal, Motorista motorista, Passageiro passageiro)
    {
        LatitudeInicio = latitudeInicio;
        LongitudeInicio = longitudeInicio;
        LatitudeFinal = latitudeFinal;
        LongitudeFinal = longitudeFinal;
        Motorista = motorista;
        Passageiro = passageiro;
        PassageiroId = passageiro.Id;
        MotoristaId = motorista.Id;
    }
    
    public Guid Id { get; init; } = NewGuid();
    public double LatitudeInicio { get; set; }
    public double LongitudeInicio { get; set; }
    public double LatitudeFinal { get; set; }
    public double LongitudeFinal { get; set; }
    public DateTime? HorarioInicio { get; set; }
    public DateTime? HorarioChegada { get; set; }
    public StatusCorrida Status { get; set; }
    public double? ValorEstimado { get; set; }
    public double? ValorTotal { get; set; }
    public int? NotaMotorista { get; set; }
    public int? NotaPassageiro { get; set; }

    [ForeignKey(nameof(Passageiro))]
    public Guid PassageiroId { get; set; }
    
    [ForeignKey(nameof(Motorista))]
    public Guid MotoristaId { get; set; }
    public Motorista Motorista { get; set; }
    public Passageiro Passageiro { get; set; }
    
    
    
    public double CalcularDistancia()
    {
        double earthRadius = 6371;
        double PI = 3.14159265358979323846;
        
        double lat1 = LatitudeFinal;
        double long1 = LongitudeFinal;
        double lat2 = LatitudeInicio;
        double long2 = LongitudeInicio;

        double distance = Acos(Sin(lat2 * PI / 180.0) * Sin(lat1 * PI / 180.0) +
                               Cos(lat2 * PI / 180.0) * Cos(lat1 * PI / 180.0) *
                               Cos((long1 - long2) * PI / 180.0)) * earthRadius;
        return distance;
    }
}