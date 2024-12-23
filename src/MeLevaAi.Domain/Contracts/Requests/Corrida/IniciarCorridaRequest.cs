using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Domain.Contracts.Requests.Corrida;

public class IniciarCorridaRequest
{
    [Required(ErrorMessage = "O campo ID do motorista é obrigatorio")]
    public Guid IdMotorista { get; set; }

    [Required(ErrorMessage = "O campo ID da corrida é obrigatoria")]
    public int IdCorrida { get; set; }
}