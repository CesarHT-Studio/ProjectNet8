namespace Biblioteca.Domain.Models;

public class Prestamo
{
    public int Id { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public int EstadoPrestamo { get; set; }
    public int IdSolicitante { get; set; } = default!;
    public DateTime FechaRegistro { get; set; }
    public int Status { get; set; } = default!;
    
    public virtual Solicitante Solicitante { get; set; } = default!;
}