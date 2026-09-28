using GestaoMicroestrutural.Domain.Events;
using GestaoMicroestrutural.Domain.Repositories;

namespace GestaoMicroestrutural.Infrastructure.EventStore;

public class EventStoreRepository : IEventStoreRepository
{
    private readonly EventStoreDbContext _context;

    public EventStoreRepository(EventStoreDbContext context)
    {
        _context = context;
    }

    public async Task AppendAsync(EventoAuditoria evento, CancellationToken cancellationToken = default)
    {
        await _context.EventosAuditoria.AddAsync(evento, cancellationToken);
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}