using Biblioteca.Application.Dtos.Libro;

namespace Biblioteca.Application.Services;

public interface ILibroService
{
    Task<IReadOnlyList<LibroSmallDto>> GetAllAsync();
    Task<LibroDto> GetByIdAsync(int id);
    Task<IList<LibroBodyDto>> GetLibrosByAutorAsync(string autor);
    Task<LibroSmallDto> CreateAsync(LibroBodyDto categoryBody);
    Task<LibroSmallDto> UpdateAsync(int id, LibroBodyDto categoryBody);
    Task<IReadOnlyList<LibroBodyDto>> GetLibrosDisponiblesAsync();
    Task DeleteAsync(int id);
}