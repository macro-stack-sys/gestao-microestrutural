using Microsoft.EntityFrameworkCore;
using GestaoMicroestrutural.Domain.Events;

namespace GestaoMicroestrutural.Infrastructure.EventStore;

public class EventStoreDbContext : DbContext
{
    public EventStoreDbContext(DbContextOptions<EventStoreDbContext> options) : base(options) { }

    public DbSet<EventoAuditoria> EventosAuditoria => Set<EventoAuditoria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("EventStore");
        modelBuilder.Entity<EventoAuditoria>(builder =>
        {
            builder.ToTable("EventoAuditoria");
            builder.HasKey(e => e.IdTransacao);
            builder.Property(e => e.PayloadJson).HasColumnType("jsonb");
        });
        base.OnModelCreating(modelBuilder);
    }
}