using System.ComponentModel.DataAnnotations;

namespace MeLevaAi.Domain.Contracts.Requests.Passageiro;

public class CadastrarPassageiroRequest
{
    [Required(ErrorMessage = "O campo nome é obrigatorio")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo CPF é obrigatorio")]
    public string Cpf { get; set; }
    
    [Required(ErrorMessage = "O campo data de nascimento é obrigatorio")]
    public DateOnly DataNascimento { get; set; }
}