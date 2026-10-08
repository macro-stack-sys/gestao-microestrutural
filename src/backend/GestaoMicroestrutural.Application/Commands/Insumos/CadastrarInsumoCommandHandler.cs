using MediatR;
using GestaoMicroestrutural.Application.Interfaces;
using GestaoMicroestrutural.Domain.Entities;

namespace GestaoMicroestrutural.Application.Commands.Insumos;

public class CadastrarInsumoCommandHandler : IRequestHandler<CadastrarInsumoCommand, Guid>
{
    private readonly ITopologiaDbContext _context;
    public CadastrarInsumoCommandHandler(ITopologiaDbContext context) => _context = context;

    public async Task<Guid> Handle(CadastrarInsumoCommand request, CancellationToken cancellationToken)
    {
        var insumo = new Insumo(
            tipo: request.Tipo,
            descricao: request.Descricao,
            unidadeMedida: request.UnidadeMedida,
            estoqueMinimo: request.EstoqueMinimo,
            tenantId: request.TenantId
        );
        _context.Insumos.Add(insumo);
        await _context.SaveChangesAsync(cancellationToken);
        return insumo.Id;
    }
}