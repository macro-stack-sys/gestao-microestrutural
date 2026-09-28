using MediatR;
using Microsoft.AspNetCore.Mvc;
using GestaoMicroestrutural.Application.Commands.RegistrarAtivo;

namespace GestaoMicroestrutural.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AtivosController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AtivosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> ResgistrarAtivo([FromBody] RegistrarAtivoCommand command, CancellationToken cancellationToken)
    {
        var aggregateId = await _mediator.Send(command, cancellationToken);
        
        return Accepted(new { AggregateId = aggregateId });
    }
}