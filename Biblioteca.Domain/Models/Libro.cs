namespace Biblioteca.Domain.Models;

public class Libro
{
    public int Id { get; set; }
    public string Isbn { get; set; }
    public string Titulo{ get; set; }
    public string Autores{ get; set; }
    public string Edicion { get; set; }
    public int Anio { get; set; }
    public int IdEditorial { get; set; } = default!;
    public DateTime FechaRegistro { get; set; }
    public int Status { get; set; } = default!;
    
    
    public virtual Editorial Editorial { get; set; } = default!;
}