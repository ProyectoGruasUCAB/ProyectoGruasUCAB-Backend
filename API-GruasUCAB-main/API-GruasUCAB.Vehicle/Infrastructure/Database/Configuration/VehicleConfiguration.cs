global using VehicleAggregate = API_GruasUCAB.Vehicle.Domain.AggregateRoot.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_GruasUCAB.Vehicle.Infrastructure.Database.Configuration
{
     public class VehicleConfiguration : IEntityTypeConfiguration<VehicleAggregate>
     {
          public void Configure(EntityTypeBuilder<VehicleAggregate> builder)
          {
               builder.HasKey(v => v.Id);

               builder.Property(v => v.Id)
                   .HasConversion(id => id.Value.ToString(), str => new VehicleId(Guid.Parse(str)))
                   .IsRequired();

               builder.Property(v => v.CivilLiability)
                   .HasConversion(cl => cl.Value, str => new VehicleCivilLiability(str))
                   .IsRequired()
                   .HasMaxLength(100);

               builder.Property(v => v.CivilLiabilityExpirationDate)
                   .HasConversion(date => date.Value.ToString("dd-MM-yyyy"), str => new VehicleCivilLiabilityExpirationDate(str))
                   .IsRequired();

               builder.Property(v => v.TrafficLicense)
                   .HasConversion(tl => tl.Value, str => new VehicleTrafficLicense(str))
                   .IsRequired()
                   .HasMaxLength(50);

               builder.Property(v => v.LicensePlate)
                   .HasConversion(lp => lp.Value, str => new VehicleLicensePlate(str))
                   .IsRequired()
                   .HasMaxLength(20);

               builder.Property(v => v.Brand)
                   .HasConversion(brand => brand.Value, str => new VehicleBrand(str))
                   .IsRequired()
                   .HasMaxLength(50);

               builder.Property(v => v.Color)
                   .HasConversion(color => color.Value, str => new VehicleColor(str))
                   .IsRequired()
                   .HasMaxLength(30);

               builder.Property(v => v.Model)
                   .HasConversion(model => model.Value, str => new VehicleModel(str))
                   .IsRequired()
                   .HasMaxLength(50);

               builder.Property(v => v.VehicleTypeId)
                   .HasConversion(id => id.Value.ToString(), str => new VehicleTypeId(Guid.Parse(str)))
                   .IsRequired();

               builder.Property(v => v.DriverId)
                   .HasConversion(
                       id => id != null ? id.Value.ToString() : null,
                       str => str != null ? new UserId(Guid.Parse(str)) : null as UserId
                   );

               builder.Property(v => v.SupplierId)
                   .HasConversion(id => id.Value.ToString(), str => new SupplierId(Guid.Parse(str)))
                   .IsRequired();
          }
     }
}