using Microsoft.EntityFrameworkCore;
using GestaoMicroestrutural.Domain.Events;

namespace GestaoMicroestrutural.Infrastructure.EventStore;

public class EventStoreDbContext : DbContext
{
    public EventStoreDbContext(DbContextOptions<EventStoreDbContext> options) : base(options) { }
    
    public DbSet<EventoAuditoria> EventosAuditoria { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("EventStore");

        modelBuilder.Entity<EventoAuditoria>().ToTable("EventoAuditoria");
        
        modelBuilder.Entity<EventoAuditoria>().HasKey(e => e.IdTransacao);

        modelBuilder.Entity<EventoAuditoria>()
            .Property(e => e.PayloadJson)
            .HasColumnType("jsonb");
    }
}