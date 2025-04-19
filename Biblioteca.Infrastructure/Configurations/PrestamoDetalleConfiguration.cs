using Biblioteca.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Configurations;

public class PrestamoDetalleConfiguration : IEntityTypeConfiguration<PrestamoDetalles>
{
    public void Configure(EntityTypeBuilder<PrestamoDetalles> builder)
    {
        builder.ToTable("prestamos_detalles");
        builder.HasKey(x => new { x.IdLibro, x.IdPrestamo });
        builder.Property(x => x.IdPrestamo).HasColumnName("id_prestamo");
        builder.Property(x => x.IdLibro).HasColumnName("id_libro");
        builder.Property(x => x.Devuelto).HasColumnName("devuelto");
        builder.Property(x => x.Mora).HasColumnName("mora");
        builder.Property(x=> x.FechaRegistro).HasColumnName("fecha_registro");
        builder.Property(x => x.Status).HasColumnName("estado");

        builder.HasOne(x => x.Libro).WithMany().HasForeignKey(x => x.IdLibro);
        builder.HasOne(x => x.Prestamo).WithMany().HasForeignKey(x => x.IdPrestamo);

    }
}