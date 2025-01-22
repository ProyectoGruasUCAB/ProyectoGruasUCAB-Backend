global using ClientAggregate = API_GruasUCAB.Policy.Infrastructure.Adapters.Entities.Client;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_GruasUCAB.Policy.Infrastructure.Database.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientAggregate>
    {
        public void Configure(EntityTypeBuilder<ClientAggregate> builder)
        {
            builder.HasKey(c => c.Id_cliente);

            builder.Property(c => c.Id_cliente)
                .IsRequired();

            builder.Property(c => c.Nombre_completo_cliente)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Cedula_cliente)
                .IsRequired();

            builder.Property(c => c.Tlf_cliente)
                .IsRequired();

            builder.Property(c => c.Fecha_nacimiento_cliente)
                .IsRequired();

            builder.HasIndex(c => c.Cedula_cliente)
                .IsUnique();
        }
    }
}