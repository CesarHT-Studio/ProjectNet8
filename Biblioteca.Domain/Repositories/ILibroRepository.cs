using Biblioteca.Domain.Cors;
using Biblioteca.Domain.Models;

namespace Biblioteca.Domain.Repositories;

public interface ILibroRepository : ICrudRepository<Libro,int>
{
    Task<IList<Libro>> FindByAutorAsync(string autor);
    Task<IReadOnlyList<Libro>> GetLibrosDisponiblesAsync();
    
}