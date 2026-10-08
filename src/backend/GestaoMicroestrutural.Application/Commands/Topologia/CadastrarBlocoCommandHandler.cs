using GestaoMicroestrutural.Application.Interfaces;
using GestaoMicroestrutural.Domain.Entities;
using MediatR;

namespace GestaoMicroestrutural.Application.Commands.Topologia;

public class CadastrarBlocoCommandHandler : IRequestHandler<CadastrarBlocoCommand, Guid>
{
    private readonly ITopologiaDbContext _context;

    public CadastrarBlocoCommandHandler(ITopologiaDbContext context) => _context = context;

    public async Task<Guid> Handle(CadastrarBlocoCommand request, CancellationToken cancellationToken)
    {
        var bloco = new Bloco(request.Nome, request.Descricao);
        
        _context.Blocos.Add(bloco);
        await _context.SaveChangesAsync(cancellationToken);

        return bloco.Id;
    }
}