using GestaoMicroestrutural.Application.Interfaces;
using GestaoMicroestrutural.Domain.Entities;
using MediatR;

namespace GestaoMicroestrutural.Application.Commands.Topologia;

public class CadastrarSalaCommandHandler : IRequestHandler<CadastrarSalaCommand, Guid>
{
    private readonly ITopologiaDbContext _context;
    public CadastrarSalaCommandHandler(ITopologiaDbContext context) => _context = context;

    public async Task<Guid> Handle(CadastrarSalaCommand request, CancellationToken cancellationToken)
    {
        var sala = new Sala(request.BlocoId, request.Nome, request.Tipo);
        _context.Salas.Add(sala);
        await _context.SaveChangesAsync(cancellationToken);
        return sala.Id;
    }
}