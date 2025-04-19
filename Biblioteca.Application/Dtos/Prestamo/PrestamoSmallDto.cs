using Biblioteca.Application.Dtos.Solicitante;

namespace Biblioteca.Application.Dtos.Prestamo;

public class PrestamoSmallDto
{
    public int Id { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public virtual SolicitanteSmallDto Solicitante { get; set; } = default!;
}