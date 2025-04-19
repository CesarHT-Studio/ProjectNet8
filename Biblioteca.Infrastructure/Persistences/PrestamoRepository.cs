using Biblioteca.Domain.Models;
using Biblioteca.Domain.Repositories;
using Biblioteca.Infrastructure.Cores.Contexts;
using Biblioteca.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Persistences;

public class PrestamoRepository : CrudRepository<Prestamo, int>, IPrestamoRepository
{
    protected InfrastructureDbContext Context { get; }

    public PrestamoRepository(InfrastructureDbContext context) : base(context)
    {
        Context = context;
    }

    public async Task<IList<Prestamo>> GetActivosAsync()
    {
        return await Context.Set<Prestamo>()
            .Where(p => p.EstadoPrestamo == 0 && p.Status == 1)
            .ToListAsync();
    }

    public async Task<IList<Prestamo>> GetVencidosAsync()
    {
        var hoy = DateTime.UtcNow;
        return await Context.Set<Prestamo>()
            .Where(p => p.FechaDevolucion < hoy && p.EstadoPrestamo == 0 && p.Status == 1)
            .ToListAsync();
    }

    public async Task<bool> MarcarComoDevueltoAsync(int id)
    {
        var prestamo = await Context.Set<Prestamo>().FindAsync(id);
        if (prestamo == null) return false;

        prestamo.EstadoPrestamo = 1;
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExtenderFechaDevolucionAsync(int id, DateTime nuevaFecha)
    {
        var prestamo = await Context.Set<Prestamo>().FindAsync(id);
        if (prestamo == null) return false;

        prestamo.FechaDevolucion = nuevaFecha;
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task SaveDetalleAsync(PrestamoDetalles detalle)
    {
        await Context.Set<PrestamoDetalles>().AddAsync(detalle);
        await Context.SaveChangesAsync();
    }
}