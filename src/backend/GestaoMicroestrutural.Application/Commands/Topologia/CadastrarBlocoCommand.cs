using MediatR;

namespace GestaoMicroestrutural.Application.Commands.Topologia;

public record CadastrarBlocoCommand(string Nome, string? Descricao) : IRequest<Guid>;