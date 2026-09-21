namespace GestaoMicroestrutural.Domain.Events;

public class EventoAuditoria
{
    public required Guid IdTransacao { get; init; }
    public required Guid AggregateId { get; init; }
    public required string TenantId { get; init; }
    public required DateTime DataHora { get; init; }
    public required Guid IdUsuarioResponsavel { get; init; }
    public required string TipoEvento { get; init; }
    public required string PayloadJson { get; init; }
}