using MeLevaAi.Application.Contracts;
using MeLevaAi.Application.Implementations.Services;
using MeLevaAi.Domain.Contracts.Repositories;
using MeLevaAi.Domain.Contracts.Requests.Corrida;
using MeLevaAi.Domain.Models;
using MeLevaAi.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using Moq;

namespace MeLevaAi.Tests.Services;

public class CorridaServiceTests
{
    private const string ValidoCpf = "06359470993";
    private static readonly DateTime DataNascimentoValida = new(2000, 9, 17);
    private static readonly DateOnly HabilitacaoValida = DateOnly.FromDateTime(new DateTime(2050, 9, 17));
    private readonly ICorridaService _corridaService;
    private readonly Mock<ICorridaRepository> _corridaRepository = new();
    private readonly Mock<IMotoristaRepository> _motoristaRepository = new ();
    private readonly Mock<IPassageiroRepository> _passageiroRepository = new();
    
    public CorridaServiceTests()
    {
        _corridaService = new CorridaService( _passageiroRepository.Object,_corridaRepository.Object, _motoristaRepository.Object);
    }
    
    [Fact]
    public void CalcularTempoEstimadoDestino_DeveRetornarTempoEmSegundosCorreto()
    {
        // Arrange
        double distancia = 10;
        int tempoEsperado = 1200; // 100 km / 50 km/h = 2 horas * 60 min/h * 60 s/min = 7200 s
        
        // Act
        int resultado = _corridaService.CalcularTempoEstimadoDestino(distancia);

        // Assert
        Assert.Equal(tempoEsperado, resultado);
    }
    
    [Fact]
    public void CalculaValorEstimado()
    {
        // Arrange
        double tempo = 10;
        int valorEsperado = 2; // 100 km / 50 km/h = 2 horas * 60 min/h * 60 s/min = 7200 s
        
        // Act
        double resultado = _corridaService.CalcularValorEstimado(tempo);

        // Assert
        Assert.Equal(valorEsperado, resultado);
    }
    
    
    [Fact]
    public void ChamarCorrida_ErroPorPassageiroNaoExistir()
    {
        var request = new ChamarCorridaRequest();
        Guid id = Guid.NewGuid();

        _passageiroRepository.Setup(x => x.Obter(id)).Returns((Passageiro?)null);


        var response = _corridaService.ChamarCorrida(id, request);
        
        Assert.NotEmpty(response.Notifications);
        _corridaRepository.Verify(v => v.Adicionar(It.IsAny<Corrida>()), Times.Never);

    }
    
    [Fact]
    public void ChamarCorrida_ErroPorPassageiroNaoEstarDisponivel()
    {
        var request = new ChamarCorridaRequest();
        Passageiro passageiro = new Passageiro("Nome", DateOnly.FromDateTime(new DateTime(1990, 10,10)), "06359470993" );
        passageiro.Indisponivel();
        
        _passageiroRepository.Setup(x => x.Obter(passageiro.Id)).Returns(passageiro);


        var response = _corridaService.ChamarCorrida(passageiro.Id, request);
        
        Assert.NotEmpty(response.Notifications);
        _corridaRepository.Verify(v => v.Adicionar(It.IsAny<Corrida>()), Times.Never);

    }
    
    [Fact]
    public void ChamarCorrida_ErroPorNaoTerMotoristasDisponiveis()
    {
        var request = new ChamarCorridaRequest();
        Passageiro passageiro = new Passageiro("Nome", DateOnly.FromDateTime(new DateTime(1990, 10,10)), "06359470993" );
        
        _passageiroRepository.Setup(x => x.Obter(passageiro.Id)).Returns(passageiro);
        _motoristaRepository.Setup(m => m.ObterDisponiveis()).Returns(new List<Motorista>());

        var response = _corridaService.ChamarCorrida(passageiro.Id, request);
        
        Assert.NotEmpty(response.Notifications);
        _corridaRepository.Verify(v => v.Adicionar(It.IsAny<Corrida>()), Times.Never);

    }
    
    [Fact]
    public void ChamarCorrida_DeveChamarCorrida()
    {
        double latitudeInicio = 1;
        double latitudeFinal = 2;
        double longitudeInicio = 1;
        double longitudeFinal = 1;
        
        var request = new ChamarCorridaRequest();
        request.LatitudeFinal = latitudeFinal;
        request.LatitudeInicio = latitudeInicio;
        request.LongitudeFinal = longitudeInicio;
        request.LongitudeFinal = longitudeFinal;

        List<Motorista> motoristasDisponiveis = new List<Motorista>();
        var nome = "Nome";
        var motorista = new Motorista(nome, DataNascimentoValida, ValidoCpf, "12345", HabilitacaoValida, Categoria.A);
        var veiculo = new Veiculo("ABC1234", "Modelo", "Vermelho", "URL", Categoria.A);
        motorista.Veiculo = veiculo;
        motoristasDisponiveis.Add(motorista);
        
        Passageiro passageiro = new Passageiro("Nome", DateOnly.FromDateTime(new DateTime(1990, 10,10)), "06359470993" );
        
        _passageiroRepository.Setup(x => x.Obter(passageiro.Id)).Returns(passageiro);
        _motoristaRepository.Setup(m => m.ObterDisponiveis()).Returns(motoristasDisponiveis);

        var response = _corridaService.ChamarCorrida(passageiro.Id, request);
        
        Assert.Empty(response.Notifications);
        _corridaRepository.Verify(v => v.Adicionar(It.IsAny<Corrida>()), Times.Once);

    }
}