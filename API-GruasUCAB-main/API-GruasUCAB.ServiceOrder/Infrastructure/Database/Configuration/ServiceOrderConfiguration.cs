global using ServiceOrderAggregate = API_GruasUCAB.ServiceOrder.Domain.AggregateRoot.ServiceOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_GruasUCAB.ServiceOrder.Infrastructure.Database.Configuration
{
    public class ServiceOrderConfiguration : IEntityTypeConfiguration<ServiceOrderAggregate>
    {
        public void Configure(EntityTypeBuilder<ServiceOrderAggregate> builder)
        {
            builder.HasKey(so => so.Id);

            builder.Property(so => so.Id)
                .HasConversion(id => id.Value.ToString(), str => new ServiceOrderId(Guid.Parse(str)))
                .IsRequired();

            builder.Property(so => so.IncidentDescription)
                .HasConversion(description => description.Value, str => new IncidentDescription(str))
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(so => so.InitialLocationDriver)
                .HasConversion(location => location.ToString(), str => Coordinates.Parse(str))
                .IsRequired();

            builder.Property(so => so.IncidentLocation)
                .HasConversion(location => location.ToString(), str => Coordinates.Parse(str))
                .IsRequired();

            builder.Property(so => so.IncidentLocationEnd)
                .HasConversion(location => location.ToString(), str => Coordinates.Parse(str))
                .IsRequired();

            builder.Property(so => so.IncidentDistance)
                .HasConversion(distance => distance.Value, str => new IncidentDistance(str))
                .IsRequired();

            builder.Property(so => so.CustomerVehicleDescription)
                .HasConversion(description => description.Value, str => new CustomerVehicleDescription(str))
                .IsRequired();

            builder.Property(so => so.IncidentCost)
                .HasConversion(cost => cost.Value, str => new IncidentCost(str))
                .IsRequired();

            builder.Property(so => so.PolicyId)
                .HasConversion(id => id.Value, str => new PolicyId(str))
                .IsRequired();

            builder.Property(so => so.StatusServiceOrder)
                .HasConversion(
                    status => status.Value.ToString(),
                    str => new StatusServiceOrder(Enum.Parse<ServiceOrderStatus>(str))
                )
                .IsRequired();

            builder.Property(so => so.IncidentDate)
                .HasConversion(
                    date => date.Value.ToString("dd-MM-yyyy"),
                    str => new IncidentDate(str)
                )
                .IsRequired();

            builder.Property(so => so.VehicleId)
                .HasConversion(id => id.Value, str => new VehicleId(str))
                .IsRequired();

            builder.Property(so => so.DriverId)
                .HasConversion(id => id.Value, str => new UserId(str))
                .IsRequired();

            builder.Property(so => so.CustomerId)
                .HasConversion(id => id.Value, str => new UserId(str))
                .IsRequired();

            builder.Property(so => so.OperatorId)
                .HasConversion(id => id.Value, str => new UserId(str))
                .IsRequired();

            builder.Property(so => so.ServiceFeeId)
                .HasConversion(id => id.Value, str => new ServiceFeeId(str))
                .IsRequired();
        }
    }
}