using API_GruasUCAB.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace API_GruasUCAB.Users.Infrastructure.Configuration
{
    public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.Property(s => s.Id).HasConversion(i => i.ToString(), str => new UserId(str)).IsRequired();
            builder.Property(s => s.Name).HasConversion(n => n.ToString(), str => new UserName(str)).IsRequired().HasMaxLength(20);
            builder.Property(s => s.Email).HasConversion(e => e.ToString(), str => new UserEmail(str)).HasMaxLength(100);
            builder.Property(s => s.Phone).HasConversion(p => p.ToString(), str => new UserPhone(str)).IsRequired().HasMaxLength(20);
            builder.Property(s => s.Cedula).HasConversion(c => c.ToString(), str => new UserCedula(str)).IsRequired().HasMaxLength(8);
            builder.Property(s => s.BirthDate).HasConversion(b => b.ToString(), str => new UserBirthDate(str)).IsRequired();

        }
    }
}