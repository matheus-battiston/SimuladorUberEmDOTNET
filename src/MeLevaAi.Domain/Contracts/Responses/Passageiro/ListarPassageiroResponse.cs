namespace MeLevaAi.Domain.Contracts.Responses.Passageiro;

public class ListarPassageiroResponse
{
    public ListarPassageiroResponse(Guid id, string nome, bool status, double nota)
    {
        Id = id;
        Nome = nome;
        Status = status;
        Nota = nota;
    }

    public Guid Id { get; set; }
    public string Nome { get; set; }
    public bool Status { get; set; }
    public double Nota { get; set; }
}