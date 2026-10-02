using MediatR;

namespace GestaoMicroestrutural.Application.Commands.Insumos;

public record CadastrarInsumoCommand(string Nome, string UnidadeMedida, decimal EstoqueMinimo) : IRequest<Guid>;
