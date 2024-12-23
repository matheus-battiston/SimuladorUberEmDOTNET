using MeLevaAi.Application.Contracts;
using MeLevaAi.Domain.Contracts.Requests.Passageiro;
using MeLevaAi.Domain.Contracts.Responses;
using MeLevaAi.Domain.Contracts.Responses.Passageiro;
using Microsoft.AspNetCore.Mvc;

namespace MeLevaAi.Api.Controllers;

[Route("/passageiros")]
[ApiController]
public class PassageiroController : ControllerBase
{
    private readonly IPassageiroService _passageiroService;

    public PassageiroController(IPassageiroService passageiroService)
    {
        _passageiroService = passageiroService;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PassageiroResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    public async Task<ActionResult<PassageiroResponse>> Cadastrar([FromBody] CadastrarPassageiroRequest request)
    {
        var response = await _passageiroService.Cadastrar(request);
        
        if (!response.IsValid())
            return BadRequest(new ErrorResponse(response.Notifications));

        return Ok(response);
    }
    
    [HttpGet]
    public ActionResult<List<ListarPassageiroResponse>> Listar() =>
        Ok(_passageiroService.ListarPassageiros());
    
    [HttpPut]
    [Route("{id:guid}/saldo")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PassageiroResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    public ActionResult<AdicionarSaldoResponse> AdicionarSaldo([FromBody] AdicionarSaldoRequest request, [FromRoute] Guid id)
    {
        var response = _passageiroService.AdicionarSaldo(request, id);
        
        if (!response.IsValid())
            return Ok(new ErrorResponse(response.Notifications));

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public ActionResult<PassageiroResponse> Obter(Guid id)
    {
        var passageiro = _passageiroService.Obter(id);

        if (passageiro is null) return NotFound();

        return Ok(passageiro);
    }

    [HttpGet("habilitados")]
    public ActionResult<List<ListarPassageiroResponse>> ListarPassageirosHabilitados()
    {
        var passageiros = _passageiroService.ListarHabilitados();

        return Ok(passageiros);
    }
    
}