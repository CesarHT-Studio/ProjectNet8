using Biblioteca.Domain.Models;
using Biblioteca.Domain.Repositories;
using Biblioteca.Infrastructure.Cores.Contexts;
using Biblioteca.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Persistences;

public class LibroRepository : CrudRepository<Libro, int>, ILibroRepository
{
    protected InfrastructureDbContext Context { get; }

    public LibroRepository(InfrastructureDbContext context) : base(context)
    {
        Context = context;
    }

    public async Task<IList<Libro>> FindByAutorAsync(string autor)
    {
        return await Context.Set<Libro>()
            .Where(l => l.Autores.Contains(autor) && l.Status == 1)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Libro>> GetLibrosDisponiblesAsync()
    {
        var librosPrestados = Context.Set<PrestamoDetalles>()
            .Where(p => p.Devuelto == 0 && p.Status == 1)
            .Select(p => p.IdLibro);

        return await Context.Set<Libro>()
            .Where(l => l.Status == 1 && !librosPrestados.Contains(l.Id))
            .ToListAsync();
    }
}