using MeLevaAi.Application.Contracts;
using MeLevaAi.Domain.Contracts.Repositories;
using MeLevaAi.Domain.Contracts.Requests.Motorista;
using MeLevaAi.Domain.Contracts.Responses;
using MeLevaAi.Domain.Contracts.Responses.Motorista;
using Microsoft.AspNetCore.Mvc;

namespace MeLevaAi.Api.Controllers;

[ApiController]
[Route("motoristas")]
public class MotoristaController : ControllerBase
{

    private readonly IMotoristaService _motoristaService;
    private readonly IMotoristaRepository _motoristaRepository;

    public MotoristaController(IMotoristaService motoristaService, IMotoristaRepository motoristaRepository)
    {
        _motoristaService = motoristaService;
        _motoristaRepository = motoristaRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<MotoristaResponse>> Listar() => 
        Ok(_motoristaService.Listar());

    [HttpGet("{id:guid}")]
    public ActionResult<MotoristaResponse> Obter([FromRoute] Guid id)
    {
        var motorista = _motoristaService.Obter(id);

        if(motorista is null) return NotFound();

        return Ok(motorista);
    }
    

    [HttpPost]
    public ActionResult<MotoristaResponse> Cadastrar([FromBody] CadastrarMoristaRequest request)
    {
        var novoMotorista = _motoristaService.Cadastrar(request);

        if (!novoMotorista.IsValid())
            return BadRequest(new ErrorResponse(novoMotorista.Notifications));

        return CreatedAtAction("Obter", new { id = novoMotorista.Id }, novoMotorista);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
   
        var removido = _motoristaService.Delete(id);

        if(!removido.IsValid())
            return BadRequest(new ErrorResponse(removido.Notifications));

        return Ok();
    }

}
