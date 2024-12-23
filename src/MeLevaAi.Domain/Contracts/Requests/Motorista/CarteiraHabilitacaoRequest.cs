using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Domain.Contracts.Requests.Motorista;

public class CarteiraHabilitacaoRequest
{
    [Required]
    public string Numero { get; set; }

    [Required]
    [Range(1, 5)]
    public int Categoria { get; set; }

    [Required]
    public DateTime DataVencimento { get; set; }
}

