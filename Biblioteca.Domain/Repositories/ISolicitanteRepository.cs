using Biblioteca.Domain.Cors;
using Biblioteca.Domain.Models;

namespace Biblioteca.Domain.Repositories;

public interface ISolicitanteRepository : ICrudRepository<Solicitante,int>
{
    Task<IList<Prestamo>> GetPrestamosBySolicitanteIdAsync(int id);
}