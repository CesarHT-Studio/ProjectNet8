using AutoMapper;
using Biblioteca.Application.Dtos.Editorial;
using Biblioteca.Application.Dtos.Editorial.Profiles;
using Biblioteca.Application.Dtos.Libro;
using Biblioteca.Domain.Models;
using Biblioteca.Domain.Repositories;

namespace Biblioteca.Application.Services.Implemetations;

public class EditorialService : IEditorialService
{
    private readonly IEditorialRepository _editorialRepository;
    private readonly ILibroRepository _libroRepository;
    private readonly IMapper _mapper;

    public EditorialService(IEditorialRepository editorialRepository, IMapper mapper,
        ILibroRepository libroRepository)
    {
        this._editorialRepository = editorialRepository;
        this._libroRepository = libroRepository;
        this._mapper = mapper;
    }

    public async Task<IReadOnlyList<EditorialDto>> GetAllAsync()
    {
        var editoriales = await _editorialRepository.FindAllAsync();

        return _mapper.Map<IReadOnlyList<EditorialDto>>(editoriales);
    }

    public async Task<EditorialDto> GetByIdAsync(int id)
    {
        var editorial = await _editorialRepository.FindByIdAsync(id);
        if (editorial is null) throw new Exception("editorial not found");
        return _mapper.Map<EditorialDto>(editorial);
    }

    public async Task<List<LibroSmallDto>> GetLibrosByEditorialAsync(int id)
    {
        var editorial = await _editorialRepository.FindByIdAsync(id);
        if (editorial is null) throw new Exception("No se encontró el editorial");

        var libros = await _libroRepository.FindAllAsync(l => l.IdEditorial == id);

        return _mapper.Map<List<LibroSmallDto>>(libros);
    }

    public async Task<EditorialDto> CreateAsync(EditorialBodyDto dto)
    {
        var editorial = _mapper.Map<Editorial>(dto);
        editorial.FechaRegistro = DateTime.UtcNow;
        editorial.Status = 1;

        await _editorialRepository.SaveAsync(editorial);

        return _mapper.Map<EditorialDto>(editorial);
    }

    public async Task<EditorialSmallDto> UpdateAsync(int id, EditorialBodyDto bodyDto)
    {
        var editorial = await _editorialRepository.FindByIdAsync(id);
        if (editorial is null) throw new Exception("No se encontro el editorial");
        _mapper.Map(bodyDto, editorial);
        await _editorialRepository.SaveAsync(editorial);
        return _mapper.Map<EditorialSmallDto>(editorial);
    }

    public async Task DeleteAsync(int id)
    {
        var editorial = await _editorialRepository.FindByIdAsync(id);
        if (editorial is null) throw new Exception("No se encontró el editorial");

        await _editorialRepository.DeleteAsync(editorial);
    }
}