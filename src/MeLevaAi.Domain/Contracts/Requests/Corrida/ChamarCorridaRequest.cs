using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Domain.Contracts.Requests.Corrida;

public class ChamarCorridaRequest
{
    [Required(ErrorMessage = "O campo latitude inicial é obrigatorio")]
    public double LatitudeInicio { get; set; }
    [Required(ErrorMessage = "O campo longitude inicial é obrigatorio")]
    public double LongitudeInicio { get; set; }
    [Required(ErrorMessage = "O campo latitude final é obrigatorio")]
    public double LatitudeFinal { get; set; }
    [Required(ErrorMessage = "O campo longitude final é obrigatorio")]
    public double LongitudeFinal { get; set; }
}