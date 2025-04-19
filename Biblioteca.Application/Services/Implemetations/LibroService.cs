using AutoMapper;
using Biblioteca.Application.Dtos.Libro;
using Biblioteca.Domain.Models;
using Biblioteca.Domain.Repositories;

namespace Biblioteca.Application.Services.Implemetations;

public class LibroService : ILibroService
{
    private readonly ILibroRepository _libroRepository;
    private readonly IMapper _mapper;

    public LibroService(IMapper mapper,
        ILibroRepository libroRepository)
    {
        this._libroRepository = libroRepository;
        this._mapper = mapper;
    }

    //obetener todos los libros
    public async Task<IReadOnlyList<LibroSmallDto>> GetAllAsync()
    {
        var libros = await _libroRepository.FindAllAsync();
        return _mapper.Map<IReadOnlyList<LibroSmallDto>>(libros);
    }

    //obtener un libro por ID
    public async Task<LibroDto> GetByIdAsync(int id)
    {
        var libro = await _libroRepository.FindByIdAsync(id);
        return _mapper.Map<LibroDto>(libro);
    }

    //encontrar libros por autor(nombre)
    public async Task<IList<LibroBodyDto>> GetLibrosByAutorAsync(string autor)
    {
        var libros = await _libroRepository.FindByAutorAsync(autor);
        return _mapper.Map<IList<LibroBodyDto>>(libros);
    }


    //agregar un nuevo libro
    public async Task<LibroSmallDto> CreateAsync(LibroBodyDto libroBody)
    {
        var libro = _mapper.Map<Libro>(libroBody);
        libro.FechaRegistro = DateTime.UtcNow;
        libro.Status = 1;

        await _libroRepository.SaveAsync(libro);
        return _mapper.Map<LibroSmallDto>(libro);
    }


    //actualizar un libro
    public async Task<LibroSmallDto> UpdateAsync(int id, LibroBodyDto libroBody)
    {
        var libro = await _libroRepository.FindByIdAsync(id);
        if (libro is null) throw new Exception("Libro not found");
        _mapper.Map(libroBody, libro);
        await _libroRepository.SaveAsync(libro);
        return _mapper.Map<LibroSmallDto>(libro);
    }

    //libros disponibles
    public async Task<IReadOnlyList<LibroBodyDto>> GetLibrosDisponiblesAsync()
    {
        var libros = await _libroRepository.GetLibrosDisponiblesAsync();
        return _mapper.Map<IReadOnlyList<LibroBodyDto>>(libros);
    }

    //eliminar un libro
    public async Task DeleteAsync(int id)
    {
        var libro = await _libroRepository.FindByIdAsync(id);
        if (libro is null) throw new Exception("Libro not found");

        await _libroRepository.DeleteAsync(libro);
    }
}