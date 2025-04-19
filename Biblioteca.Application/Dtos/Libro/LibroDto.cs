using Biblioteca.Application.Dtos.Editorial;
using Biblioteca.Application.Dtos.Editorial.Profiles;

namespace Biblioteca.Application.Dtos.Libro;

public class LibroDto
{
    public int Id { get; set; }
    public string Isbn { get; set; }
    public string Titulo{ get; set; }
    public string Autores{ get; set; }
    public string Edicion { get; set; }
    public int Anio { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int Status { get; set; } = default!;

    public virtual EditorialSmallDto Editorial { get; set; } = default!;
}