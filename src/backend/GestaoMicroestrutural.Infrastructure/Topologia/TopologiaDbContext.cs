using Microsoft.EntityFrameworkCore;
using GestaoMicroestrutural.Domain.Entities;
using GestaoMicroestrutural.Application.Interfaces;

namespace GestaoMicroestrutural.Infrastructure.Topologia;

public class TopologiaDbContext : DbContext, ITopologiaDbContext
{
    public TopologiaDbContext(DbContextOptions<TopologiaDbContext> options) : base(options) { }
    
    public DbSet<Bloco> Blocos => Set<Bloco>();
    public DbSet<Sala> Salas => Set<Sala>();
    public DbSet<Insumo> Insumos => Set<Insumo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Topologia");

        modelBuilder.Entity<Bloco>(builder =>
        {
            builder.ToTable("Bloco");
            builder.HasKey(b => b.Id);

            builder.HasMany(b => b.Salas)
                   .WithOne(s => s.Bloco)
                   .HasForeignKey(s => s.BlocoId)
                   .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Sala>(builder =>
        {
            builder.ToTable("Sala");
            builder.HasKey(s => s.Id);
        });

        modelBuilder.Entity<Insumo>(builder =>
        {
            builder.ToTable("Insumo");
            builder.HasKey(i => i.Id);
        });
    }
}