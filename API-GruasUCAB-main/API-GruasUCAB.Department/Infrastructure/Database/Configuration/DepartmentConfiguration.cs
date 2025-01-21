global using DepartmentAggregate = API_GruasUCAB.Department.Domain.AggregateRoot.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_GruasUCAB.Department.Infrastructure.Database.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<DepartmentAggregate>
    {
        public void Configure(EntityTypeBuilder<DepartmentAggregate> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasConversion(id => id.Value.ToString(), str => new DepartmentId(Guid.Parse(str)))
                .IsRequired();

            builder.Property(d => d.Name)
                .HasConversion(name => name.Value, str => new DepartmentName(str))
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Description)
                .HasConversion(description => description.Value, str => new DepartmentDescription(str))
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}