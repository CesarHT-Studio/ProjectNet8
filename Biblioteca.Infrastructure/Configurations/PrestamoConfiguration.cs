using Biblioteca.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Configurations;

public class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo>
{
    public void Configure(EntityTypeBuilder<Prestamo> builder)
    {
        builder.ToTable("prestamos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x=> x.FechaPrestamo).HasColumnName("fecha_prestamo");
        builder.Property(x => x.FechaDevolucion).HasColumnName("fecha_devolucion");
        builder.Property(x=> x.EstadoPrestamo).HasColumnName("estado_prestamo");
        builder.Property(x=> x.IdSolicitante).HasColumnName("id_solicitante");
        builder.Property(x => x.FechaRegistro).HasColumnName("fecha_registro");
        builder.Property(x => x.Status).HasColumnName("estado");
        
        builder.HasOne(x=> x.Solicitante).WithMany().HasForeignKey(x=> x.IdSolicitante);
    }
}