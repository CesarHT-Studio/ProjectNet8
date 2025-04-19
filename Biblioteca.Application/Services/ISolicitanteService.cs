using Biblioteca.Application.Dtos.Prestamo;
using Biblioteca.Application.Dtos.Solicitante;
using Biblioteca.Application.Dtos.Solicitante.Profiles;

namespace Biblioteca.Application.Services;

public interface ISolicitanteService
{
    Task<IReadOnlyList<SolicitanteSmallDto>> GetAllAsync();
    Task<SolicitanteDto> GetByIdAsync(int id);
    Task<IList<PrestamoDto>> GetPrestamosBySolicitanteIdAsync(int id);
    Task<SolicitanteSmallDto> CreateAsync(SolicitanteBodyDto solicitanteBody);
    Task<SolicitanteSmallDto?> UpdateAsync(int id, SolicitanteBodyDto solicitanteBody);
}