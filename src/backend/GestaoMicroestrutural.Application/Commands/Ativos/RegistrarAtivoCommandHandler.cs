using MediatR;
using System.Text.Json;
using GestaoMicroestrutural.Domain.Events;
using GestaoMicroestrutural.Domain.Repositories;

namespace GestaoMicroestrutural.Application.Commands.Ativos;

public class RegistrarAtivoCommandHandler : IRequestHandler<RegistrarAtivoCommand, Guid>
{
    private readonly IEventStoreRepository _repository;

    public RegistrarAtivoCommandHandler(IEventStoreRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(RegistrarAtivoCommand request, CancellationToken cancellationToken)
    {
        var aggregateId = Guid.NewGuid();

        var evento = new EventoAuditoria
        {
            IdTransacao = Guid.NewGuid(),
            AggregateId = aggregateId,
            TenantId = request.TenantId,
            TipoEvento = "AtivoRegistradoEvent",
            PayloadJson = JsonSerializer.Serialize(request),
            DataHora = DateTime.UtcNow,
            IdUsuarioResponsavel = Guid.NewGuid()
        };
        
        await _repository.AppendAsync(evento, cancellationToken);

        return aggregateId;
    }
}