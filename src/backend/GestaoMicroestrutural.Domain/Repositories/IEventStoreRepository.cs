using GestaoMicroestrutural.Domain.Events;

namespace GestaoMicroestrutural.Domain.Repositories;

public interface IEventStoreRepository
{
    Task AppendAsync(EventoAuditoria evento, CancellationToken cancellationToken = default);
}