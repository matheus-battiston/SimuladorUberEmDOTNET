using MeLevaAi.Application.Contracts;
using MeLevaAi.Domain.Contracts.Requests.Veiculo;
using MeLevaAi.Domain.Contracts.Responses;
using MeLevaAi.Domain.Contracts.Responses.Veiculo;
using Microsoft.AspNetCore.Mvc;

namespace MeLevaAi.Api.Controllers;

[ApiController]
[Route("veiculos")]
public class  VeiculoController : ControllerBase
{

    private readonly IVeiculoService _veiculoService;

    public VeiculoController(IVeiculoService veiculoService)
    {
        _veiculoService = veiculoService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<VeiculoResponse>> Listar() =>
        Ok(_veiculoService.Listar());

    [HttpGet("{id:guid}")]
    public ActionResult<VeiculoResponse> Obter(Guid id)
    {
        var veiculo = _veiculoService.Obter(id);

        if(veiculo is null) return NotFound();

        return Ok(veiculo);
    }

    [HttpPost]
    public ActionResult<VeiculoResponse> Cadastrar([FromBody] CadastrarVeiculoRequest request)
    {
        var novoVeiculo = _veiculoService.Cadastrar(request);

        if(!novoVeiculo.IsValid())
        {
            return BadRequest(new ErrorResponse(novoVeiculo.Notifications));
        }

        return CreatedAtAction("Obter", new { id = novoVeiculo.Id }, novoVeiculo);
    }
    
}