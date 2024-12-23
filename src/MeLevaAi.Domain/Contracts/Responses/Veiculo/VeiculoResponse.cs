using MeLevaAi.Domain.Validations;

namespace MeLevaAi.Domain.Contracts.Responses.Veiculo;

public class VeiculoResponse : Notifiable
{
    public VeiculoResponse(string placa, string modelo, string cor, string? fotoUrl)
    {
        Placa = placa;
        Modelo = modelo;
        Cor = cor;
        FotoUrl = fotoUrl;
    }

    public VeiculoResponse()
    {
        
    }
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public string Cor  { get; set; }
    public string? FotoUrl { get; set; }

    public Guid Id { get; set; }
    
}