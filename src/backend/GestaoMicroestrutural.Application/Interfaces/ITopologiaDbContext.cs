using GestaoMicroestrutural.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoMicroestrutural.Application.Interfaces;

public interface ITopologiaDbContext
{
    DbSet<Bloco> Blocos { get; }
    DbSet<Sala> Salas { get; }
    DbSet<Insumo> Insumos { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}