using MeLevaAi.Application.Contracts;
using MeLevaAi.Application.Implementations.Services;
using MeLevaAi.Domain.Contracts.Repositories;
using MeLevaAi.Domain.Contracts.Requests.Passageiro;
using MeLevaAi.Domain.Models;
using Moq;

namespace MeLevaAi.Tests.Services
{
	public class PassageiroServiceTests
	{
		private readonly IPassageiroService _passageiroService;
		private readonly Mock<IPassageiroRepository> _passageiroRepository = new();
		private const string ValidoCpf = "06359470993";
		private static readonly DateOnly DataNascimentoValida = DateOnly.FromDateTime(new DateTime(2000, 9, 17));


		public PassageiroServiceTests()
		{
			_passageiroService = new PassageiroService(_passageiroRepository.Object);
		}

		[Fact]
		public void ValidarPassageiro_DeveRetornarNotificacao_QuandoCpfInvalido()
		{
			var respostaEsperada = "CPF invalido";
			var request = new CadastrarPassageiroRequest
			{
				Cpf = "1234"
			};

			var response = _passageiroService.ValidarPassageiro(request);
			
			Assert.Equal(respostaEsperada, response);
		}
		
		[Fact]
		public void ValidarPassageiro_DeveRetornarNotificacao_QuandoCpfJaExistir()
		{
			
			var respostaEsperada = "CPF ja foi cadastrado anteriormente";
			var request = new CadastrarPassageiroRequest
			{
				Cpf = "06359470993"
			};
			
			_passageiroRepository.Setup(x => x.ExisteCpf(request.Cpf)).Returns(true);

			var response = _passageiroService.ValidarPassageiro(request);
			
			Assert.Equal(respostaEsperada, response);
		}
		
		[Fact]
		public void ValidarPassageiro_DeveRetornarNotificacao_QuandoMenorDeIdade()
		{
			
			var respostaEsperada = "O passageiro nao tem a idade minima de 16 anos";
			var request = new CadastrarPassageiroRequest
			{
				Cpf = "06359470993",
				DataNascimento = DateOnly.FromDateTime(new DateTime(2020, 9, 17))
			};
			
			_passageiroRepository.Setup(x => x.ExisteCpf(request.Cpf)).Returns(false);

			var response = _passageiroService.ValidarPassageiro(request);
			
			Assert.Equal(respostaEsperada, response);
		}
		
		[Fact]
		public void ValidarPassageiro_NaoDeveRetornarNotificacao_QuandoMaiorDe16()
		{
			
			var request = new CadastrarPassageiroRequest
			{
				Cpf = "06359470993",
				DataNascimento = DateOnly.FromDateTime(new DateTime(2000, 9, 17))
			};
			
			_passageiroRepository.Setup(x => x.ExisteCpf(request.Cpf)).Returns(false);

			var response = _passageiroService.ValidarPassageiro(request);
			
			Assert.Null(response);
		}
		
		[Fact]
		public void ValidarPassageiro_NaoDeveRetornarNotificacao_QuandoCpfValidoEMaiorDe16()
		{
			var request = new CadastrarPassageiroRequest
			{
				Cpf = "06359470993",
				DataNascimento = DateOnly.FromDateTime(new DateTime(2000, 9, 17))

			};
			
			_passageiroRepository.Setup(x => x.ExisteCpf(request.Cpf)).Returns(false);

			var response = _passageiroService.ValidarPassageiro(request);
			
			Assert.Null(response);
		}
		
		
		[Fact]
		public void TesteObterExistente()
		{
			var nome = "Nome do passageiro";


			var passageiro = new Passageiro(nome, DataNascimentoValida, ValidoCpf);
			_passageiroRepository.Setup(x => x.Obter(passageiro.Id)).Returns(passageiro);

			var result = _passageiroService.Obter(passageiro.Id);
			Assert.NotNull(result);
			Assert.Equal(result.Id, passageiro.Id);
			Assert.Equal(result.Nome, nome);
		}

		[Fact]
		public void Obter_DeveRetornarNull_QuandoNaoExistirPassageiro()
		{
			var id = Guid.NewGuid();

			_passageiroRepository.Setup(x => x.Obter(id)).Returns((Passageiro?)null);

			var result = _passageiroService.Obter(id);
			Assert.Null(result);
		}
		
		[Fact]
		public async Task Cadastrar_DeveCadastrarCorretamente()
		{
			var request = new CadastrarPassageiroRequest
			{
				Nome = "Nome",
				Cpf = ValidoCpf,
				DataNascimento = DataNascimentoValida,
			};
			_passageiroRepository.Setup(x => x.ExisteCpf(request.Cpf)).Returns(false);


			var response = await _passageiroService.Cadastrar(request);
			Assert.NotNull(response);
			Assert.Empty(response.Notifications);
			_passageiroRepository.Verify(v => v.Cadastrar(It.IsAny<Passageiro>()), Times.Once);

		}

		[Fact]
		public async Task Cadastrar_NaoDeveCadastrarQuandoExistirErro()
		{
			var request = new CadastrarPassageiroRequest { Nome = "", DataNascimento = DateOnly.FromDateTime(DateTime.Now), Cpf = ValidoCpf};

			// Chame a função Cadastrar e verifique se o resultado é o esperado
			var response = await _passageiroService.Cadastrar(request);
			Assert.NotEmpty(response.Notifications);
			_passageiroRepository.Verify(v => v.Cadastrar(It.IsAny<Passageiro>()), Times.Never);
		}
		
		[Fact]
		public void AdicionarSaldo_SaldoMenorQueZero_DeveRetornarNotificacao()
		{
			var request = new AdicionarSaldoRequest { ValorDeposito = -10 };
			var id = Guid.NewGuid();

			var result = _passageiroService.AdicionarSaldo(request, id);

			Assert.NotEmpty(result.Notifications);
			_passageiroRepository.Verify(v => v.Alterar(It.IsAny<Passageiro>()), Times.Never);

		}

		[Fact]
		public void AdicionarSaldo_PassageiroNaoExiste_DeveRetornarNotificacao()
		{
			// Arrange
			var request = new AdicionarSaldoRequest { ValorDeposito = 100 };
			var id = Guid.NewGuid();
			_passageiroRepository.Setup(x => x.Obter(id)).Returns((Passageiro)null);

			var result = _passageiroService.AdicionarSaldo(request, id);

			Assert.NotEmpty(result.Notifications);
			_passageiroRepository.Verify(v => v.Alterar(It.IsAny<Passageiro>()), Times.Never);

		}

		[Fact]
		public void AdicionarSaldo_Sucesso_DeveRetornarNovoSaldo()
		{
			var valorDeposito = 50;
			var passageiro = new Passageiro("Nome", DataNascimentoValida, ValidoCpf);
			_passageiroRepository.Setup(x => x.Obter(passageiro.Id)).Returns(passageiro);
			var request = new AdicionarSaldoRequest { ValorDeposito = valorDeposito };

			// Act
			var result = _passageiroService.AdicionarSaldo(request, passageiro.Id);

			// Assert
			Assert.Equal(valorDeposito, result.NovoSaldo);
			Assert.Equal(passageiro.Nome, result.Nome);
			Assert.Equal(passageiro.Id, result.Id);
		}
	}
}

