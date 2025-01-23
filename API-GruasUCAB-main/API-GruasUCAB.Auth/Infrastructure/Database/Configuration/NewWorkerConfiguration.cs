namespace API_GruasUCAB.Auth.Infrastructure.Database.Configuration
{
    public class NewWorkerConfiguration : IEntityTypeConfiguration<NewWorker>
    {
        public void Configure(EntityTypeBuilder<NewWorker> builder)
        {
            builder.ToTable("WorkersRegistered");
            builder.HasKey(w => w.WorkerId);

            builder.Property(w => w.WorkerId)
                .IsRequired();

            builder.Property(w => w.DepartmentId)
                .IsRequired();

            builder.Property(w => w.Position)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}