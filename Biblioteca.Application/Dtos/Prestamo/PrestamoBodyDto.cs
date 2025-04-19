using Biblioteca.Application.Dtos.Solicitante;

namespace Biblioteca.Application.Dtos.Prestamo;

public class PrestamoBodyDto
{   
    public int IdSolicitante { get; set; } = default!;
    public DateTime? FechaDevolucion { get; set; }
    public List<int> LibrosIds { get; set; } = new();
}