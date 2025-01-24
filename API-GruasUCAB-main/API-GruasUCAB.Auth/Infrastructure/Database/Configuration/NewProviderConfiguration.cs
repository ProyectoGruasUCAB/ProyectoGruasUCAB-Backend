namespace API_GruasUCAB.Auth.Infrastructure.Database.Configuration
{
     public class NewProviderConfiguration : IEntityTypeConfiguration<NewProvider>
     {
          public void Configure(EntityTypeBuilder<NewProvider> builder)
          {
               builder.ToTable("ProvidersRegistered");

               builder.HasKey(p => p.ProviderId);

               builder.Property(p => p.ProviderId)
                   .IsRequired();

               builder.Property(p => p.SupplierId)
                   .IsRequired();
          }
     }
}