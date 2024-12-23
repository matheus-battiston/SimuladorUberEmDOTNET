namespace MeLevaAi.Domain.Contracts.Responses.Corrida;

public class CorridaResponse
{
    public CorridaResponse(Guid id, string nomeMotorista, string status, DateTime? horarioInicio, string nomePassageiro)
    {
        Id = id;
        NomeMotorista = nomeMotorista;
        Status = status;
        NomePassageiro = nomePassageiro;
        if (horarioInicio is not null)
        {
            HorarioInicio = horarioInicio;

        }
    }

    public CorridaResponse()
    {
        
    }


    public Guid Id { get; set; }
    public string NomeMotorista  { get; set; }
    public string Status { get; set; }
    public DateTime? HorarioInicio { get; set; }
    public string NomePassageiro { get; set; }
}
