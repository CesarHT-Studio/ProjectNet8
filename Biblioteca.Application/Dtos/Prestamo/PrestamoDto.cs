using Biblioteca.Application.Dtos.Solicitante;

namespace Biblioteca.Application.Dtos.Prestamo;

public class PrestamoDto
{
    public int Id { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public int EstadoPrestamo { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int Status { get; set; } = default!;
    
    public virtual SolicitanteSmallDto Solicitante { get; set; } = default!;
}