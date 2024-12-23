using AutoMapper;
using MeLevaAi.Domain.Contracts.Responses.Corrida;
using MeLevaAi.Domain.Models;

namespace MeLevaAi.Application.Implementations.Mappers;

public static class CorridaMapper
{
    public static ChamarCorridaResponse ToResponse(int tempoEsperadoDeChegada, Corrida novaCorrida, Veiculo veiculo,
        Motorista motorista)
    {
        var response = new ChamarCorridaResponse(novaCorrida.Id, veiculo.ToVeiculoResponse(), tempoEsperadoDeChegada,
            motorista.Nome);
        return response;
    }

    public static CorridaResponse ToCorridaResponse(this Corrida corrida)
    {
        return new CorridaResponse(corrida.Id, corrida.Motorista.Nome, corrida.Status.ToString(), corrida.HorarioInicio, 
            corrida.Passageiro.Nome);
    }

    public static FinalizarCorridaResponse FinalizarCorridaResponse(this Corrida corrida)
    {
        var response = new FinalizarCorridaResponse((DateTime)corrida.HorarioChegada, (Double)corrida.ValorTotal);
        return response;
    }

    public static DetalharCorridaResponse? ToCorridaDetalheResponse(Corrida corrida)
    {
        var config = new MapperConfiguration(cfg => 
            { cfg.CreateMap<Corrida, DetalharCorridaResponse>()
                .ForMember(dest => dest.Motorista, opt => opt.Ignore())
                .ForMember(dest => dest.Passageiro, opt => opt.Ignore())
                .ForMember(dest => dest.Distancia, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore()); });
                
        var mapper = config.CreateMapper();
        var response = mapper.Map<Corrida, DetalharCorridaResponse>(corrida);
        response.Distancia = corrida.CalcularDistancia();
        response.Motorista = corrida.Motorista.ToMotoristaResponse();
        response.Passageiro = PassageiroMapper.ToResponse(corrida.Passageiro);
        response.Status = corrida.Status.ToString();
        

        return response;
    }
}