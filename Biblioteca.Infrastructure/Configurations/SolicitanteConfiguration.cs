using Biblioteca.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Configurations;

public class SolicitanteConfiguration : IEntityTypeConfiguration<Solicitante>
{
    public void Configure(EntityTypeBuilder<Solicitante> builder)
    {
        builder.ToTable("solicitantes");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x=> x.NombreCompleto).HasColumnName("nombre_completo");
        builder.Property(x => x.DocumentoIdentidad).HasColumnName("documento_identidad");
        builder.Property(x=> x.Email).HasColumnName("email");
        builder.Property(x=> x.Telefono).HasColumnName("telefono");
        builder.Property(x=> x.FechaRegistro).HasColumnName("fecha_registro");
        builder.Property(x=> x.Status).HasColumnName("estado");
    }
}