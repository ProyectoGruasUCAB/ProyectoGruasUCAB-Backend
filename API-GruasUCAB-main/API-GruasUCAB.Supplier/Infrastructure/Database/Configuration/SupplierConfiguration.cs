global using SupplierAggregate = API_GruasUCAB.Supplier.Domain.AggregateRoot.Supplier;

namespace API_GruasUCAB.Supplier.Infrastructure.Database.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<SupplierAggregate>
    {
        public void Configure(EntityTypeBuilder<SupplierAggregate> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasConversion(id => id.Value.ToString(), str => new SupplierId(Guid.Parse(str)))
                .IsRequired();

            builder.Property(s => s.Name)
                .HasConversion(name => name.Value, str => new SupplierName(str))
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(s => s.Name)
                .IsUnique();

            builder.Property(s => s.Type)
                .HasConversion(
                    type => type.Value.ToString(),
                    str => new SupplierType(Enum.Parse<SupplierTypeEnum>(str))
                )
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}