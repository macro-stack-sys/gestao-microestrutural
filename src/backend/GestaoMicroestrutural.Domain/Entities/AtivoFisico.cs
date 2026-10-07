using GestaoMicroestrutural.Domain.Events;

namespace GestaoMicroestrutural.Domain.Entities;

public enum NaturezaAtivo { Permanente, Consumo }
public enum StatusAtivo { Ativo, EmManutencao, Descartado }

public abstract class AtivoFisico
{
    public Guid Id { get; protected set; }
    public string TenantId { get; protected set; } = null!;
    public NaturezaAtivo Natureza { get; protected set; }
    public string? Patrimonio { get; protected set; }
    public string Descricao { get; protected set; } = null!;
    public StatusAtivo Status { get; protected set; }
    
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    
    protected AtivoFisico() { }

    protected AtivoFisico(Guid id, string tenantId, NaturezaAtivo natureza, string descricao, string? patrimonio = null)
    {
        Id = id;
        TenantId = tenantId;
        Natureza = natureza;
        Descricao = descricao;
        Patrimonio = patrimonio;
        Status = StatusAtivo.Ativo;
    }
    
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public void Descartar()
    {
        if (Status == StatusAtivo.Descartado)
            throw new InvalidOperationException("Este ativo já se encontra descartado.");

        Status = StatusAtivo.Descartado; 
    }
}