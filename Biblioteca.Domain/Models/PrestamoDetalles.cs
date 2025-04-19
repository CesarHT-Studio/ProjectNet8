namespace Biblioteca.Domain.Models;

public class PrestamoDetalles
{
    public int IdPrestamo { get; set; } = default!;
    public int IdLibro { get; set; } = default!;
    public int Devuelto { get; set; }
    public decimal Mora { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int Status { get; set; } = default!;
    
    public virtual Libro Libro { get; set; } = default!;
    public virtual Prestamo Prestamo { get; set; } = default!;
}