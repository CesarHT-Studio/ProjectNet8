using Biblioteca.Application.Dtos.Editorial;
using Biblioteca.Application.Dtos.Editorial.Profiles;
using Biblioteca.Application.Dtos.Libro;
using Biblioteca.Domain.Models;

namespace Biblioteca.Application.Services;

public interface IEditorialService
{
    Task<IReadOnlyList<EditorialDto>> GetAllAsync();
    Task<EditorialDto> GetByIdAsync(int id);
    Task<List<LibroSmallDto>> GetLibrosByEditorialAsync(int id);
    Task<EditorialDto> CreateAsync(EditorialBodyDto editorialBody);
    Task<EditorialSmallDto> UpdateAsync(int id, EditorialBodyDto bodyDto);
    Task DeleteAsync(int id);
}