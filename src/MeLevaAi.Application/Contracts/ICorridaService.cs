using MeLevaAi.Domain.Contracts.Requests.Corrida;
using MeLevaAi.Domain.Contracts.Responses.Corrida;
using MeLevaAi.Domain.Models;

namespace MeLevaAi.Application.Contracts;

public interface ICorridaService
{
    public IEnumerable<CorridaResponse> Listar();
    public DetalharCorridaResponse? Obter(Guid id);
    public ChamarCorridaResponse? ChamarCorrida(Guid idPassageiro, ChamarCorridaRequest request);
    public IniciarCorridaResponse? IniciarCorrida(Guid id);
    public FinalizarCorridaResponse FinalizarCorrida(Guid id);
    public Motorista? DefinirMotoristaDaCorrida();
    public int CalcularTempoEsperadoDeChegada();
    public int CalcularTempoEstimadoDestino(double distancia);
    public double CalcularValorEstimado(double tempo);

}