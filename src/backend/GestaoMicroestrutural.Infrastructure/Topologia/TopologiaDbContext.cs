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
            
            builder.Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Descricao)
                .HasMaxLength(255);
            
            builder.HasMany(b => b.Salas)
                   .WithOne(s => s.Bloco)
                   .HasForeignKey(s => s.BlocoId)
                   .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Sala>(builder =>
        {
            builder.ToTable("Sala");
            builder.HasKey(s => s.Id);
            
            builder.Property(s => s.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Tipo)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Insumo>(builder =>
        {
            builder.ToTable("Insumo");
            builder.HasKey(i => i.Id);
            
            builder.Property(i => i.TenantId).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Descricao).IsRequired().HasMaxLength(255);
            builder.Property(i => i.Patrimonio).HasMaxLength(100);
            
            builder.Property(i => i.Natureza).HasConversion<string>().IsRequired();
            builder.Property(i => i.Status).HasConversion<string>().IsRequired();

            builder.Property(i => i.Tipo).IsRequired().HasMaxLength(100);
            builder.Property(i => i.UnidadeMedida).IsRequired().HasMaxLength(20);
            builder.Property(i => i.EstoqueMinimo).HasColumnType("decimal(18,2)");
            builder.Property(i => i.QuantidadeDisponivel).HasColumnType("decimal(18,2)");

            builder.Ignore(i => i.DomainEvents);
        });
    }
}