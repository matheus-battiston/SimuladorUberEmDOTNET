using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Domain.Contracts.Requests.Motorista;

public class CadastrarMoristaRequest
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    public string CPF { get; set; }

    [Required]
    public string HabilitacaoNumero { get; set; }
    
    [Required] public int HabilitacaoCategoria { get; set; }
    [Required] public DateOnly HabilitacaoDataVencimento { get; set; }
    
}
