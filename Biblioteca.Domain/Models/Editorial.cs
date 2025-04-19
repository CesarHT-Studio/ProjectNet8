namespace Biblioteca.Domain.Models;

public class Editorial
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public DateTime  FechaRegistro { get; set; }
    public int Status { get; set; } = default!;
    
}