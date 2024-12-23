using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Domain.Contracts.Requests.Veiculo;

public class CadastrarVeiculoRequest
{
    [Required]
    public string Placa { get; set; }
    
    [Required]
    public string Modelo { get; set; }
    
    [Required]
    public string Cor { get; set; }

    public string? FotoUrl { get; set; }
    
    [Required]
    [Range(1, 5)]
    public int Categoria { get; set; }

    [Required]
    public Guid ProprietarioId { get; set; }
}