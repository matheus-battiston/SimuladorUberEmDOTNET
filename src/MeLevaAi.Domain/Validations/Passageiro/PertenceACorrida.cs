using MeLevaAi.Domain.Models;

namespace MeLevaAi.Domain.Validations.Passageiro;

public class PertenceACorrida
{
    public static bool Motorista(Motorista motorista, Corrida corrida)
    {
        return motorista.Id == corrida.MotoristaId;
    }
}