using MeLevaAi.Domain.Contracts.Responses.Corrida;
using MeLevaAi.Domain.Validations;

namespace MeLevaAi.Domain.Contracts.Responses.Passageiro;

public class PassageiroResponse : Notifiable
{
    public PassageiroResponse()
    {
        
    }

    public PassageiroResponse(Guid id, string nome, double nota, int numeroDeCorridas, double saldoEmConta, List<CorridaResponse> corridas)
    {
        Id = id;
        Nome = nome;
        Nota = nota;
        NumeroDeCorridas = numeroDeCorridas;
        SaldoEmConta = saldoEmConta;
        Corridas = corridas;
    }


    public Guid Id { get; set; }
    public string Nome { get; set; }
    public double Nota { get; set; }
    public int NumeroDeCorridas { get; set; }
    public double SaldoEmConta { get; set; }
    public List<CorridaResponse> Corridas { get; set; }
    

}