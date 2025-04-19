using Biblioteca.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Configurations;

public class EditorialConfiguration : IEntityTypeConfiguration<Editorial>
{
    public void Configure(EntityTypeBuilder<Editorial> builder)
    {
        builder.ToTable("editoriales");
        builder.HasKey(x => x.Id);
        
        //relacionamos cada una de las propiedades de mi modelo con las columnas de mi tabla
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x=> x.Codigo).HasColumnName("codigo");
        builder.Property(x => x.Nombre).HasColumnName("nombre");
        builder.Property(x => x.FechaRegistro).HasColumnName("fecha_registro");
        builder.Property(x => x.Status).HasColumnName("estado");
    }
}