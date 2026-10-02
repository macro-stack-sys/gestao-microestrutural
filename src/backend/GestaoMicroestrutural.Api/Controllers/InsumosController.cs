using MediatR;
using Microsoft.AspNetCore.Mvc;
using GestaoMicroestrutural.Application.Commands.Insumos;

namespace GestaoMicroestrutural.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InsumosController : ControllerBase
{
    private readonly IMediator _mediator;

    public InsumosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarInsumo([FromBody] CadastrarInsumoCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(CadastrarInsumo), new { id }, id);
    }
}