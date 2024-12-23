using MeLevaAi.Application.Contracts;
using MeLevaAi.Domain.Contracts.Requests.Corrida;
using MeLevaAi.Domain.Contracts.Responses;
using MeLevaAi.Domain.Contracts.Responses.Corrida;
using Microsoft.AspNetCore.Mvc;

namespace MeLevaAi.Api.Controllers;

[ApiController]
[Route("corridas")]
public class CorridaController : ControllerBase
{

    private readonly ICorridaService _corridaService;

    public CorridaController(ICorridaService corridaService)
    {
        _corridaService = corridaService;
    }


    [HttpGet]
    public ActionResult<IEnumerable<CorridaResponse>> Listar() =>
        Ok(_corridaService.Listar());

    [HttpGet("{id:guid}")]
    public ActionResult<CorridaResponse> Obter(Guid id)
    {
        var corrida = _corridaService.Obter(id);

        if (corrida is null) return NotFound();

        return Ok(corrida);
    }


    [HttpPost("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChamarCorridaResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    public ActionResult<ChamarCorridaResponse> ChamarCorrida([FromBody] ChamarCorridaRequest request, [FromRoute] Guid id)
    {
        var response = _corridaService.ChamarCorrida(id, request);
        
        if (!response!.IsValid())
            return BadRequest(new ErrorResponse(response.Notifications));

        return Ok(response);
    }
    
    [HttpPut]
    [Route("iniciar/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChamarCorridaResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    public ActionResult<IniciarCorridaResponse> IniciarCorrida([FromRoute] Guid id)
    {
        var response = _corridaService.IniciarCorrida(id);
        
        if (!response!.IsValid())
            return BadRequest(new ErrorResponse(response.Notifications));

        return Ok(response);
    }

    [HttpPut]
    [Route("finalizar/{id:guid}")]
    public ActionResult<FinalizarCorridaResponse> FinalizarCorrida(Guid id)
    {
        var response = _corridaService.FinalizarCorrida(id);

        if (!response!.IsValid())
            return BadRequest(new ErrorResponse(response.Notifications));

        return Ok(response);
    }
    
}