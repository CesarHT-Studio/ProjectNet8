using AutoMapper;
using Biblioteca.Application.Dtos.Prestamo;
using Biblioteca.Domain.Models;
using Biblioteca.Domain.Repositories;

namespace Biblioteca.Application.Services.Implemetations;

public class PrestamoService : IPrestamoService
{
    private readonly IPrestamoRepository _prestamoRepository;
    private readonly IMapper _mapper;

    public PrestamoService(
        IPrestamoRepository prestamoRepository,
        IMapper mapper)
    {
        this._prestamoRepository = prestamoRepository;
        this._mapper = mapper;
    }

    public async Task<IReadOnlyList<PrestamoDto>> GetAllAsync()
    {
        var prestamo = await _prestamoRepository.FindAllAsync();
        return _mapper.Map<IReadOnlyList<PrestamoDto>>(prestamo);
    }

    public async Task<PrestamoDto> GetByIdAsync(int id)
    {
        var prestamo = await _prestamoRepository.FindByIdAsync(id);
        if (prestamo == null) throw new Exception("Prestamo not found");
        return _mapper.Map<PrestamoDto>(prestamo);
    }

    public async Task<IList<PrestamoDto>> GetPrestamosActivosAsync()
    {
        var prestamos = await _prestamoRepository.GetActivosAsync();
        return _mapper.Map<IList<PrestamoDto>>(prestamos);
    }

    public async Task<IList<PrestamoDto>> GetPrestamosVencidosAsync()
    {
        var prestamos = await _prestamoRepository.GetVencidosAsync();
        return _mapper.Map<IList<PrestamoDto>>(prestamos);
    }

    public async Task<PrestamoSmallDto> CreateAsync(PrestamoBodyDto prestamoBody)
    {
        var prestamo = _mapper.Map<Prestamo>(prestamoBody);
        prestamo.FechaRegistro = DateTime.UtcNow;
        prestamo.FechaPrestamo = DateTime.UtcNow;
        prestamo.EstadoPrestamo = 0;
        prestamo.Status = 1;

        await _prestamoRepository.SaveAsync(prestamo);

        foreach (var libroId in prestamoBody.LibrosIds)
        {
            var detalle = new PrestamoDetalles
            {
                IdPrestamo = prestamo.Id,
                IdLibro = libroId,
                Devuelto = 0,
                Mora = 0,
                FechaRegistro = DateTime.UtcNow,
                Status = 1
            };

            await _prestamoRepository.SaveDetalleAsync(detalle);
        }

        return _mapper.Map<PrestamoSmallDto>(prestamo);
    }

    public async Task<bool> MarcarComoDevueltoAsync(int id)
    {
        return await _prestamoRepository.MarcarComoDevueltoAsync(id);
    }

    public async Task<bool> ExtenderFechaDevolucionAsync(int id, DateTime nuevaFechaDevolucion)
    {
        return await _prestamoRepository.ExtenderFechaDevolucionAsync(id, nuevaFechaDevolucion);
    }
}