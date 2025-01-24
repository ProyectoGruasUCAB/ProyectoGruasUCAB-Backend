namespace API_GruasUCAB.Auth.Infrastructure.Database.Configuration
{
     public class NewDriverConfiguration : IEntityTypeConfiguration<NewDriver>
     {
          public void Configure(EntityTypeBuilder<NewDriver> builder)
          {
               builder.ToTable("DriversRegistered");

               builder.HasKey(d => d.DriverId);

               builder.Property(d => d.DriverId)
                   .IsRequired();

               builder.Property(d => d.SupplierId)
                   .IsRequired();
          }
     }
}