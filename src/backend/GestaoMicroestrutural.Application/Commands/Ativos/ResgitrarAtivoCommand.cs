using MediatR;

namespace GestaoMicroestrutural.Application.Commands.Ativos;

public class RegistrarAtivoCommand : IRequest<Guid>
{
    public required string TenantId { get; init; }
    public required string Descricao { get; init; }
    public required string Patrimonio { get; init; }
}