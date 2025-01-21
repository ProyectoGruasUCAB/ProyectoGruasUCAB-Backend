global using ServiceFeeAggregate = API_GruasUCAB.ServiceFee.Domain.AggregateRoot.ServiceFee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_GruasUCAB.ServiceFee.Infrastructure.Database.Configuration
{
    public class ServiceFeeConfiguration : IEntityTypeConfiguration<ServiceFeeAggregate>
    {
        public void Configure(EntityTypeBuilder<ServiceFeeAggregate> builder)
        {
            builder.HasKey(sf => sf.Id);

            builder.Property(sf => sf.Id)
                .HasConversion(id => id.Value.ToString(), str => new ServiceFeeId(Guid.Parse(str)))
                .IsRequired();

            builder.Property(sf => sf.Name)
                .HasConversion(name => name.Value, str => new ServiceFeeName(str))
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sf => sf.Price)
                .HasConversion(price => price.Value, value => new ServiceFeePrice(value))
                .IsRequired();

            builder.Property(sf => sf.PriceKm)
                .HasConversion(priceKm => priceKm.Value, value => new ServiceFeePriceKm(value))
                .IsRequired();

            builder.Property(sf => sf.Radius)
                .HasConversion(radius => radius.Value, value => new ServiceFeeRadius(value))
                .IsRequired();

            builder.Property(sf => sf.Description)
                .HasConversion(description => description.Value, value => new ServiceFeeDescription(value))
                .IsRequired()
                .HasMaxLength(250);

            builder.HasIndex(sf => sf.Name).IsUnique();
        }
    }
}