using MediatR;
using Microsoft.AspNetCore.Mvc;
using GestaoMicroestrutural.Application.Commands.Topologia;

namespace GestaoMicroestrutural.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TopologiaController : ControllerBase
{
    private readonly IMediator _mediator;

    public TopologiaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("blocos")]
    public async Task<IActionResult> CadastrarBloco([FromBody] CadastrarBlocoCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(CadastrarBloco), new { id }, id);
    }

    [HttpPost("salas")]
    public async Task<IActionResult> CadastrarSala([FromBody] CadastrarSalaCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(CadastrarSala), new { id }, id);
    }
}