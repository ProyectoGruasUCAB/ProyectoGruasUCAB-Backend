namespace API_GruasUCAB.Database.DepartmentWorker.Configuration
{
     public class DepartmentWorkerConfiguration : IEntityTypeConfiguration<Entities.DepartmentWorker>
     {
          public void Configure(EntityTypeBuilder<Entities.DepartmentWorker> builder)
          {
               builder.HasKey(dw => new { dw.WorkerId, dw.DepartmentId });

               builder.HasOne(dw => dw.Worker)
                   .WithMany()
                   .HasForeignKey(dw => dw.WorkerId)
                   .OnDelete(DeleteBehavior.Restrict);

               builder.HasOne(dw => dw.Department)
                   .WithMany()
                   .HasForeignKey(dw => dw.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);
          }
     }
}