using MediatR;

namespace GestaoMicroestrutural.Application.Commands.Insumos;

public record CadastrarInsumoCommand(string Tipo, string Descricao, string UnidadeMedida, decimal EstoqueMinimo, string TenantId) : IRequest<Guid>;
