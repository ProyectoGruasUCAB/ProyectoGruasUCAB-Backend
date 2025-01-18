namespace API_GruasUCAB.Users.Infrastructure.Database.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasConversion(id => id.Value.ToString(), str => new UserId(Guid.Parse(str)))
                .IsRequired();

            builder.Property(a => a.Name)
                .HasConversion(name => name.Value, str => new UserName(str))
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Email)
                .HasConversion(email => email.Value, str => new UserEmail(str))
                .HasMaxLength(100);

            builder.Property(a => a.Phone)
                .HasConversion(phone => phone.Value, str => new UserPhone(str))
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.Cedula)
                .HasConversion(cedula => cedula.Value, str => new UserCedula(str))
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(a => a.BirthDate)
                .HasConversion(
                    birthDate => birthDate.Value.ToString("dd-MM-yyyy"),
                    str => new UserBirthDate(str)
                )
                .IsRequired();

        }
    }
}