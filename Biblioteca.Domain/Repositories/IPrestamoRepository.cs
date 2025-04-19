using System.Linq.Expressions;
using Biblioteca.Domain.Cors;
using Biblioteca.Domain.Models;

namespace Biblioteca.Domain.Repositories;

public interface IPrestamoRepository : ICrudRepository<Prestamo,int>
{
    Task<IList<Prestamo>> GetActivosAsync();
    Task<IList<Prestamo>> GetVencidosAsync();
    Task<bool> MarcarComoDevueltoAsync(int id);
    Task<bool> ExtenderFechaDevolucionAsync(int id, DateTime nuevaFecha);
    
    Task SaveDetalleAsync(PrestamoDetalles detalle);

}