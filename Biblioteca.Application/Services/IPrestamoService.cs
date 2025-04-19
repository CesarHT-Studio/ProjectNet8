using Biblioteca.Application.Dtos.Prestamo;

namespace Biblioteca.Application.Services;

public interface IPrestamoService
{
    Task<IReadOnlyList<PrestamoDto>> GetAllAsync();
    Task<PrestamoDto> GetByIdAsync(int id);
    Task<IList<PrestamoDto>> GetPrestamosActivosAsync();
    Task<IList<PrestamoDto>> GetPrestamosVencidosAsync();
    Task<PrestamoSmallDto> CreateAsync(PrestamoBodyDto prestamoBody);
    Task<bool> MarcarComoDevueltoAsync(int id);
    Task<bool> ExtenderFechaDevolucionAsync(int id, DateTime nuevaFechaDevolucion);
}