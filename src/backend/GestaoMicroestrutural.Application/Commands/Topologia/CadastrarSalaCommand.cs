using MediatR;

namespace GestaoMicroestrutural.Application.Commands.Topologia;

public record CadastrarSalaCommand(Guid BlocoId, string Nome, string? Tipo) : IRequest<Guid>;

