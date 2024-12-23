using MeLevaAi.Domain.Contracts.Responses.Veiculo;
using MeLevaAi.Domain.Validations;

namespace MeLevaAi.Domain.Contracts.Responses.Corrida;

public class ChamarCorridaResponse : Notifiable
{
    public ChamarCorridaResponse(Guid idCorrida, VeiculoResponse veiculo, int tempoEsperado, string nomeMotorista)
    {
        IdCorrida = idCorrida;
        Veiculo = veiculo;
        TempoEsperado = tempoEsperado;
        NomeMotorista = nomeMotorista;
    }

    public ChamarCorridaResponse()
    {
    }

    public Guid IdCorrida { get; set; }
    public VeiculoResponse Veiculo { get; set; }
    public int TempoEsperado { get; set; }
    public string NomeMotorista { get; set; }
    
}