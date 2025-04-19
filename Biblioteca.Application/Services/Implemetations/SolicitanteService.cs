using AutoMapper;
using Biblioteca.Application.Dtos.Prestamo;
using Biblioteca.Application.Dtos.Solicitante;
using Biblioteca.Application.Dtos.Solicitante.Profiles;
using Biblioteca.Domain.Models;
using Biblioteca.Domain.Repositories;

namespace Biblioteca.Application.Services.Implemetations;

public class SolicitanteService : ISolicitanteService
{
    private readonly ISolicitanteRepository _solicitanteRepository;
    private readonly IMapper _mapper;

    public SolicitanteService(
        ISolicitanteRepository solicitanteRepository, 
        IMapper mapper)
    {
        this._mapper = mapper;
        this._solicitanteRepository = solicitanteRepository;
    }
    
    public async Task<IReadOnlyList<SolicitanteSmallDto>> GetAllAsync()
    {
        var solicitantes = await _solicitanteRepository.FindAllAsync();
        return _mapper.Map<List<SolicitanteSmallDto>>(solicitantes);
    }

    public async Task<SolicitanteDto> GetByIdAsync(int id)
    {
        var solicitante = await _solicitanteRepository.FindByIdAsync(id);
        if (solicitante == null) throw new Exception("Solicitante not found");
        return _mapper.Map<SolicitanteDto>(solicitante);
    }

    public async Task<IList<PrestamoDto>> GetPrestamosBySolicitanteIdAsync(int id)
    {
        var prestamo = await _solicitanteRepository.GetPrestamosBySolicitanteIdAsync(id);
        if (prestamo == null) throw new Exception("Prestamo not found");
        return _mapper.Map<IList<PrestamoDto>>(prestamo);
    }

    public async Task<SolicitanteSmallDto> CreateAsync(SolicitanteBodyDto solicitanteBody)
    {
        var solicitante = _mapper.Map<Solicitante>(solicitanteBody);
        
        solicitante.FechaRegistro = DateTime.UtcNow;
        solicitante.Status = 1;
        
        await _solicitanteRepository.SaveAsync(solicitante);
        return _mapper.Map<SolicitanteSmallDto>(solicitante);
    }

    public async Task<SolicitanteSmallDto?> UpdateAsync(int id, SolicitanteBodyDto solicitanteBody)
    {
        var solicitante = await _solicitanteRepository.FindByIdAsync(id);
        if (solicitante is null) throw new Exception("Solicitante not found");
        _mapper.Map(solicitanteBody, solicitante);
        await _solicitanteRepository.SaveAsync(solicitante);
        return _mapper.Map<SolicitanteSmallDto>(solicitante);
    }
}