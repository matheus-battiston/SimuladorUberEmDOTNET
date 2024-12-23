using static System.DateTime;

namespace MeLevaAi.Domain.Validations.Passageiro;

public class IdadePassageiro
{
    private const int IdadeMinima = 16;
    private const int DiasDoAno = 365;
    public static object Validar(DateOnly dataNascimento)
    {
        DateOnly hoje = DateOnly.FromDateTime(Now);
        int idade = hoje.DayNumber - dataNascimento.DayNumber;
        idade /= DiasDoAno;

        return idade > IdadeMinima;
    }
}