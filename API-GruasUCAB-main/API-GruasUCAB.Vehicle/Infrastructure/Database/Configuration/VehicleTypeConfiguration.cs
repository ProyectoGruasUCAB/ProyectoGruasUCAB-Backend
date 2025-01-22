global using VehicleTypeAggregate = API_GruasUCAB.Vehicle.Domain.Entity.VehicleType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_GruasUCAB.Vehicle.Infrastructure.Database.Configuration
{
    public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleTypeAggregate>
    {
        public void Configure(EntityTypeBuilder<VehicleTypeAggregate> builder)
        {
            builder.HasKey(vt => vt.Id);

            builder.Property(vt => vt.Id)
                .HasConversion(id => id.Value.ToString(), str => new VehicleTypeId(Guid.Parse(str)))
                .IsRequired();

            builder.Property(vt => vt.Type)
                .HasConversion(
                    type => type.ToString(),
                    str => Enum.Parse<VehicleTypeEnumerate>(str))
                .IsRequired();

            builder.Property(vt => vt.DescripcionVehicleType)
                .HasConversion(
                    desc => desc.Value,
                    str => new DescripcionVehicleType(str))
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(vt => vt.Type).IsUnique();
        }
    }
}