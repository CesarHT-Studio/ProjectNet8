using Biblioteca.Domain.Models;
using Biblioteca.Domain.Repositories;
using Biblioteca.Infrastructure.Cores.Contexts;
using Biblioteca.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Persistences;

public class SolicitanteRepository : CrudRepository<Solicitante, int>, ISolicitanteRepository
{
    protected InfrastructureDbContext Context { get; }

    public SolicitanteRepository(InfrastructureDbContext context) : base(context)
    {
        Context = context;
    }
    public async Task<IList<Prestamo>> GetPrestamosBySolicitanteIdAsync(int id)
    {
        return await Context.Set<Prestamo>()
            .Include(p => p.Solicitante)
            .Where(x => x.IdSolicitante == id)
            .ToListAsync();
    }
}