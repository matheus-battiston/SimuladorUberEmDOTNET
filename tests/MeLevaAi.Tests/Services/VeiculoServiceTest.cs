using System.Runtime.InteropServices.JavaScript;
using MeLevaAi.Application.Contracts;
using MeLevaAi.Application.Implementations.Services;
using MeLevaAi.Domain.Contracts.Repositories;
using MeLevaAi.Domain.Contracts.Requests.Veiculo;
using MeLevaAi.Domain.Models;
using Moq;

namespace MeLevaAi.Tests.Services;

public class VeiculoServiceTest
{
    private readonly IVeiculoService _veiculoService;
    private readonly Mock<IVeiculoRepository> _veiculoRepository = new();
    private readonly Mock<IMotoristaRepository> _motoritaRepository = new();


    public VeiculoServiceTest()
    {
        _veiculoService = new VeiculoService(_veiculoRepository.Object, _motoritaRepository.Object);

    }
    
    [Fact]
    public void Cadastrar_DeveCadastrarVeiculo()
    {
        
        var motorista = new Motorista { Id = Guid.NewGuid(), HabilitacaoCategoria = Categoria.B };
        var request = new CadastrarVeiculoRequest
        {
            Placa = "ABC1234",
            ProprietarioId = motorista.Id,
            Categoria = (int)Categoria.B,
            Modelo = "Gol",
            Cor = "Vermelho",
            FotoUrl = "Link"
        };
        _motoritaRepository.Setup(m => m.Obter(motorista.Id)).Returns(motorista);

        
        var response = _veiculoService.Cadastrar(request);

        
        Assert.Empty(response.Notifications);
        _veiculoRepository.Verify(v => v.Cadastrar(It.IsAny<Veiculo>()), Times.Once);
        _motoritaRepository.Verify(m => m.Alterar(motorista), Times.Once);
    }
    
    [Fact]
    public void Cadastrar_NaoDeveCadastrar_QuandoMotoristaNaoExistir()
    {
        var id = Guid.NewGuid();
        var request = new CadastrarVeiculoRequest
        {
            Placa = "ABC1234",
            ProprietarioId = id,
            Categoria = (int)Categoria.B,
            Modelo = "Gol",
            Cor = "Vermelho",
            FotoUrl = "Link"
        };
        _motoritaRepository.Setup(m => m.Obter(id)).Returns((Motorista?)null);

        // Act
        var response = _veiculoService.Cadastrar(request);

        // Assert
        Assert.NotEmpty(response.Notifications);
        _veiculoRepository.Verify(v => v.Cadastrar(It.IsAny<Veiculo>()), Times.Never);
        _motoritaRepository.Verify(m => m.Alterar(It.IsAny<Motorista>()), Times.Never);
    }
    
    
    [Fact]
    public void Cadastrar_NaoDeveCadastrar_QuandoCategoriasIncompativeis()
    {
        
        var motorista = new Motorista { Id = Guid.NewGuid(), HabilitacaoCategoria = Categoria.A };
        var request = new CadastrarVeiculoRequest
        {
            Placa = "ABC1234",
            ProprietarioId = motorista.Id,
            Categoria = (int)Categoria.B,
            Modelo = "Gol",
            Cor = "Vermelho",
            FotoUrl = "Link"
        };
        _motoritaRepository.Setup(m => m.Obter(motorista.Id)).Returns(motorista);

        
        var response = _veiculoService.Cadastrar(request);

        
        Assert.NotEmpty(response.Notifications);
        _veiculoRepository.Verify(v => v.Cadastrar(It.IsAny<Veiculo>()), Times.Never);
        _motoritaRepository.Verify(m => m.Alterar(It.IsAny<Motorista>()), Times.Never);
    }
}