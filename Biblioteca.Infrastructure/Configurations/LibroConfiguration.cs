using Biblioteca.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Configurations;

public class LibroConfiguration : IEntityTypeConfiguration<Libro>
{
    public void Configure(EntityTypeBuilder<Libro> builder)
    {  
        
        builder.ToTable("libros");
        builder.HasKey(x => x.Id);
        
        //relacionamos cada una de las propiedades de mi modelo con las columnas de mi tabla
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Isbn).HasColumnName("isbn");
        builder.Property(x=> x.Titulo).HasColumnName("titulo");
        builder.Property(x=> x.Autores).HasColumnName("autores");
        builder.Property(x=> x.Edicion).HasColumnName("edicion");
        builder.Property(x=> x.Anio).HasColumnName("anio");
        builder.Property(x=> x.IdEditorial).HasColumnName("id_editorial");
        builder.Property(x=> x.FechaRegistro).HasColumnName("fecha_registro");
        builder.Property(x => x.Status).HasColumnName("estado");
        
        builder.HasOne(x => x.Editorial).WithMany().HasForeignKey(x => x.IdEditorial);
        
    }
}