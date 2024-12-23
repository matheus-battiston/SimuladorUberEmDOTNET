using MeLevaAi.Domain.Validations.Passageiro;

namespace MeLevaAi.Tests.Validacoes;

public class IdadePassageiroTest
{
    [Fact]
    public void IdadePassageiro_DeveRetornarVerdadeiro_QuandoIdadeAdequada()
    {
        var dataNascimento =  DateOnly.FromDateTime(new DateTime(1997, 9, 17)) ;
        
        Assert.True((bool)IdadePassageiro.Validar(dataNascimento));
    }
    
    [Fact]
    public void IdadePassageiro_DeveRetornarFalso_QuandoMenorDe16()
    {
        var dataNascimento =  DateOnly.FromDateTime(new DateTime(2020, 9, 17)) ;
        
        Assert.False((bool)IdadePassageiro.Validar(dataNascimento));
    }

}