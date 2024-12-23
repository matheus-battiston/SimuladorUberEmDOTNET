using MeLevaAi.Application.Contracts;
using MeLevaAi.Application.Implementations.Mappers;
using MeLevaAi.Domain.Contracts.Repositories;
using MeLevaAi.Domain.Contracts.Requests.Corrida;
using MeLevaAi.Domain.Contracts.Responses.Corrida;
using MeLevaAi.Domain.Models;
using MeLevaAi.Domain.Validations;
using MeLevaAi.Domain.Validations.Passageiro;
using static MeLevaAi.Domain.Models.StatusCorrida;


namespace MeLevaAi.Application.Implementations.Services;

public class CorridaService : ICorridaService
{
    
    private const int TempoMinimoChegada = 5;
    private const int TempoMaximoChegada = 10;
    private const string SemMotoristasDisponiveis = "Nao existem motoristas disponiveis no momento";
    private const string PassageiroNaoExiste = "O passageiro informado nao existe";
    private const string PassageiroNaoEstaDisponivel = "O passageiro informado ja tem uma corrida em andamento";
    private const string CorridaNaoExiste = "A corrida informada nao existe";
    private const string MotoristaNaoExiste = "O motorista informado nao existe";
    private const string MotoristaNaoPertence = "O motorista nao pertence a esta corrida";
    private const string CorridaNaoPodeSerIniciada = "Esta corrida nao esta com status SOLICITADA";
    private const int VelocidadeMedia = 30;
    private const double ValorPorSegundo = 0.2;
    private readonly IPassageiroRepository _passageiroRepository;
    private readonly ICorridaRepository _corridaRepository;
    private readonly IMotoristaRepository _motoristaRepository;
    

    public CorridaService(IPassageiroRepository passageiroRepository, ICorridaRepository corridaRepository, IMotoristaRepository motoristaRepository)
    {
        _passageiroRepository = passageiroRepository;
        _corridaRepository = corridaRepository;
        _motoristaRepository = motoristaRepository;
    }

    public IEnumerable<CorridaResponse> Listar() =>
         _corridaRepository.Listar().Select(corrida => corrida.ToCorridaResponse());
    
    public DetalharCorridaResponse? Obter(Guid id)
    {
        var corrida = _corridaRepository.Obter(id);

        return CorridaMapper.ToCorridaDetalheResponse(corrida);
    }

    public ChamarCorridaResponse ChamarCorrida(ChamarCorridaRequest request)
    {
        return ChamarCorrida(new Guid(), request);
    }

    public ChamarCorridaResponse ChamarCorrida(Guid idPassageiro, ChamarCorridaRequest request)
    {
        var response = new ChamarCorridaResponse();

        var passageiroDaCorrida = _passageiroRepository.Obter(idPassageiro);
        if (passageiroDaCorrida is null)
        {
            response.AddNotification(new Notification(PassageiroNaoExiste));
            return response;
        }

        if (!passageiroDaCorrida.Disponivel)
        {
            response.AddNotification(new Notification(PassageiroNaoEstaDisponivel));
            return response;
        }


        var motoristaSelecionado = DefinirMotoristaDaCorrida();
        if (motoristaSelecionado is null)
        {
            response.AddNotification(new Notification(SemMotoristasDisponiveis));
            return response;
        }

        var veiculo = motoristaSelecionado.Veiculo;

        motoristaSelecionado.Disponivel = false;
        passageiroDaCorrida.Indisponivel();


        Corrida novaCorrida = new Corrida(request.LatitudeInicio, request.LongitudeInicio, request.LatitudeFinal,
            request.LongitudeFinal, motoristaSelecionado, passageiroDaCorrida);
        novaCorrida.Status = SOLICITADA;

        _corridaRepository.Adicionar(novaCorrida);

        var tempoEsperadoDeChegada = CalcularTempoEsperadoDeChegada();
        response = CorridaMapper.ToResponse(tempoEsperadoDeChegada, novaCorrida, veiculo, motoristaSelecionado);
        return response;
    }

    public IniciarCorridaResponse IniciarCorrida(Guid id)
    {
        var response = new IniciarCorridaResponse();

        var corrida = _corridaRepository.Obter(id);
        if (corrida is null)
        {
            response.AddNotification(new Notification(CorridaNaoExiste));
            return response;
        }

        if (corrida.Status != SOLICITADA)
        {
            response.AddNotification(new Notification(CorridaNaoPodeSerIniciada));
            return response;
        }

        Motorista? motorista = _motoristaRepository.Obter(corrida.Motorista.Id);
        if (motorista is null)
        {
            response.AddNotification(new Notification(MotoristaNaoExiste));
            return response;
        }

        if (!PertenceACorrida.Motorista(motorista, corrida))
        {
            response.AddNotification(new Notification(MotoristaNaoPertence));
            return response;
        }

        var distancia = corrida.CalcularDistancia();
        var tempoEstimado = CalcularTempoEstimadoDestino(distancia);
        var valorEstimado = CalcularValorEstimado(tempoEstimado);

        corrida.HorarioInicio = DateTime.Now;
        corrida.ValorEstimado = valorEstimado;
        corrida.Status = INICIADA;

        response.ValorEstimado = valorEstimado;
        response.TempoEstimado = tempoEstimado;

        _corridaRepository.Alterar(corrida);

        return response;
    }


    public double CalcularValorEstimado(double tempo)
    {
        return tempo * ValorPorSegundo;
    }

    public int CalcularTempoEstimadoDestino(double distancia)
    {
        var sessenta = 60;

        double tempoEmHoras = distancia / VelocidadeMedia;
        int tempoEmSegundos = (int)Math.Ceiling(tempoEmHoras * sessenta * sessenta);

        return tempoEmSegundos;
    }

    public int CalcularTempoEsperadoDeChegada()
    {
        Random random = new Random();
        return random.Next(TempoMinimoChegada, TempoMaximoChegada);
    }

    public Motorista? DefinirMotoristaDaCorrida()
    {
        int numeroMotorista;
        List<Motorista> motoristasDisponiveis = _motoristaRepository.ObterDisponiveis().ToList();
        if (motoristasDisponiveis.Count() == 0)
        {
            return null;
        }

        Random random = new Random();
        if (motoristasDisponiveis.Count() == 1)
        {
            numeroMotorista = 0;
        }
        else
        {
            numeroMotorista = random.Next(0, motoristasDisponiveis.Count() - 1);
        }
        Motorista motoristaSelecionado = motoristasDisponiveis[numeroMotorista];
        return motoristaSelecionado;
    }

    public FinalizarCorridaResponse FinalizarCorrida(Guid id)
    {

        var response = new FinalizarCorridaResponse();

        var corrida = _corridaRepository.Obter(id);

        if (corrida is null)
        {
            response.AddNotification(new Notification(CorridaNaoExiste));
            return response;
        }

        if (corrida.Status != INICIADA)
        {
            response.AddNotification(new Notification("Corrida ainda n�o foi iniciada."));
            return response;
        }

        corrida.HorarioChegada = DateTime.Now;

        TimeSpan? ts = corrida.HorarioChegada - corrida.HorarioInicio;
        var tempoSegundos = ts?.TotalSeconds;
        var valorCorrida = tempoSegundos * 0.2;

        var passageiro = _passageiroRepository.Obter(corrida.Passageiro.Id);

        if (passageiro?.SaldoEmConta < valorCorrida)
        {
            response.AddNotification(new Notification("Saldo do passageiro � inferior ao valor da corrida."));
            return response;
        }

        if (passageiro is null)
        {
            response.AddNotification(new Notification(MotoristaNaoExiste));
            return response;
        }

        corrida.ValorTotal = valorCorrida;
        corrida.Status = FINALIZADA;

        var motorista = _motoristaRepository.Obter(corrida.Motorista.Id);

        if (motorista is null)
        {
            response.AddNotification(new Notification(MotoristaNaoExiste));
            return response;
        }

        motorista.Disponivel = true;
        passageiro.RealizarPagamento((float) valorCorrida);
        motorista.Receber((float)valorCorrida);
        passageiro.TornarDisponivel();

        _corridaRepository.Alterar(corrida);

        return corrida.FinalizarCorridaResponse();
    }
    
}