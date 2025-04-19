using Biblioteca.Application.Dtos.Editorial.Profiles;

namespace Biblioteca.Application.Dtos.Libro;

public class LibroSmallDto
{
    public int Id { get; set; }
    public string Titulo{ get; set; }
    public string Autores{ get; set; }
    public virtual EditorialSmallDto Editorial { get; set; } = default!;
}