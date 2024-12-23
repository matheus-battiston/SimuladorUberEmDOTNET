using MeLevaAi.Application.Contracts;
using MeLevaAi.Application.Implementations.Services;
using MeLevaAi.Domain.Contracts.Repositories;
using MeLevaAi.Domain.Contracts.Requests.Motorista;
using MeLevaAi.Domain.Models;
using Moq;

namespace MeLevaAi.Tests.Services;

public class MotoristaServiceTests
{
    private readonly IMotoristaService _motoristaService;
    private readonly Mock<IMotoristaRepository> _motoristaRepository = new();
    private const string ValidoCpf = "06359470993";
    private static readonly DateTime DataNascimentoValida = new(2000, 9, 17);
    private static readonly DateOnly HabilitacaoValida = DateOnly.FromDateTime(new DateTime(2050, 9, 17));

    
    
    public MotoristaServiceTests()
    {
        _motoristaService = new MotoristaService(_motoristaRepository.Object);
    }

    [Fact]
    public void TesteObterExistente()
    {
        var nome = "Nome do motorista";

        var motorista = new Motorista(nome, DataNascimentoValida, ValidoCpf, "12345", HabilitacaoValida, Categoria.A);

        _motoristaRepository.Setup(x => x.Obter(motorista.Id)).Returns(motorista);

        var result = _motoristaService.Obter(motorista.Id);
        Assert.NotNull(result);
        Assert.Equal(result.Id, motorista.Id);
        Assert.Equal(result.Nome, nome);
    }
    
    [Fact]
    public void Obter_DeveRetornarNull_QuandoNaoExistirPassageiro()
    {
        var id = Guid.NewGuid();

        _motoristaRepository.Setup(x => x.Obter(id)).Returns((Motorista?)null);

        var result = _motoristaService.Obter(id);
        Assert.Null(result);
    }

    [Fact]
    public void Cadastrar_DeveRetornarNotification_QuandoMenorDe18Anos()
    {
        var nome = "Nome do motorista";

        var motorista = new CadastrarMoristaRequest();
        motorista.DataNascimento = new DateTime(2020, 10, 10);
        motorista.Nome = nome;
        motorista.HabilitacaoDataVencimento = HabilitacaoValida;
        motorista.CPF = ValidoCpf;
        motorista.HabilitacaoCategoria = (int)Categoria.A;


        var response = _motoristaService.Cadastrar(motorista);
        
        Assert.NotEmpty(response.Notifications);
        _motoristaRepository.Verify(v => v.Cadastrar(It.IsAny<Motorista>()), Times.Never);


    }
    
    [Fact]
    public void Cadastrar_DeveRetornarNotification_QuandoCPFInvalido()
    {
        var nome = "Nome do motorista";

        var motorista = new CadastrarMoristaRequest();
        motorista.Nome = nome;
        motorista.HabilitacaoDataVencimento = HabilitacaoValida;
        motorista.CPF = "1234567";
        motorista.HabilitacaoCategoria = (int)Categoria.A;
        motorista.DataNascimento = DataNascimentoValida;


        var response = _motoristaService.Cadastrar(motorista);
        
        Assert.NotEmpty(response.Notifications);
        _motoristaRepository.Verify(v => v.Cadastrar(It.IsAny<Motorista>()), Times.Never);


    }
    
    
    [Fact]
    public void Cadastrar_DeveRetornarNotification_QuandoHabilitacaoVencida()
    {
        var nome = "Nome do motorista";

        var motorista = new CadastrarMoristaRequest();
        motorista.Nome = nome;
        motorista.HabilitacaoDataVencimento = new DateOnly(2020, 10, 10);
        motorista.CPF = ValidoCpf;
        motorista.HabilitacaoCategoria = (int)Categoria.A;
        motorista.DataNascimento = DataNascimentoValida;


        var response = _motoristaService.Cadastrar(motorista);
        
        Assert.NotEmpty(response.Notifications);
        _motoristaRepository.Verify(v => v.Cadastrar(It.IsAny<Motorista>()), Times.Never);


    }
    
    [Fact]
    public void Cadastrar_DeveRetornarNotification_QuandoCPFJaExiste()
    {
        var nome = "Nome do motorista";

        var motorista = new CadastrarMoristaRequest();
        motorista.Nome = nome;
        motorista.HabilitacaoDataVencimento = HabilitacaoValida;
        motorista.CPF = ValidoCpf;
        motorista.HabilitacaoCategoria = (int)Categoria.A;
        motorista.DataNascimento = DataNascimentoValida;
        
        _motoristaRepository.Setup(x => x.ObterPorCPF(motorista.CPF)).Returns(true);


        var response = _motoristaService.Cadastrar(motorista);
        
        Assert.NotEmpty(response.Notifications);
        _motoristaRepository.Verify(v => v.Cadastrar(It.IsAny<Motorista>()), Times.Never);


    }
    
    [Fact]
    public void Cadastrar_DeveCadastrarMotorista()
    {
        var nome = "Nome do motorista";

        var motorista = new CadastrarMoristaRequest();
        motorista.Nome = nome;
        motorista.HabilitacaoDataVencimento = HabilitacaoValida;
        motorista.CPF = ValidoCpf;
        motorista.HabilitacaoCategoria = (int)Categoria.A;
        motorista.DataNascimento = DataNascimentoValida;

        _motoristaRepository.Setup(x => x.ObterPorCPF(motorista.CPF)).Returns(false);


        var response = _motoristaService.Cadastrar(motorista);
        
        Assert.Empty(response.Notifications);
        _motoristaRepository.Verify(v => v.Cadastrar(It.IsAny<Motorista>()), Times.Once);
    }
    
    [Fact]
    public void Delete_DeveRetornarNotificacao_QuandoMotoristaNaoExistir()
    {
        Guid id = new Guid();

        _motoristaRepository.Setup(x => x.Obter(id)).Returns((Motorista?)null);


        var response = _motoristaService.Delete(id);
        
        Assert.NotEmpty(response.Notifications);
        _motoristaRepository.Verify(v => v.Delete(It.IsAny<Motorista>()), Times.Never);
    }
    
    [Fact]
    public void Delete_DeveRetornarNotificacao_QuandoMotoristaTiverVeiculo()
    {
        var nome = "Nome";
        var motorista = new Motorista(nome, DataNascimentoValida, ValidoCpf, "12345", HabilitacaoValida, Categoria.A);
        motorista.Veiculo = new Veiculo();
        
        
        _motoristaRepository.Setup(x => x.Obter(motorista.Id)).Returns(motorista);


        var response = _motoristaService.Delete(motorista.Id);
        
        Assert.NotEmpty(response.Notifications);
        _motoristaRepository.Verify(v => v.Delete(It.IsAny<Motorista>()), Times.Never);
    }
    
    
    [Fact]
    public void Delete_DeveDeletarMotorista()
    {
        var nome = "Nome";
        var motorista = new Motorista(nome, DataNascimentoValida, ValidoCpf, "12345", HabilitacaoValida, Categoria.A);
        
        
        _motoristaRepository.Setup(x => x.Obter(motorista.Id)).Returns(motorista);


        var response = _motoristaService.Delete(motorista.Id);
        
        Assert.Empty(response.Notifications);
        _motoristaRepository.Verify(v => v.Delete(motorista), Times.Once);
    }
}