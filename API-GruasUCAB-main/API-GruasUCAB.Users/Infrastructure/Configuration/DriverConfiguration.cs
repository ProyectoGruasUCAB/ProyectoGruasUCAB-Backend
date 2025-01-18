using API_GruasUCAB.Users.Domain.Entities;
using API_GruasUCAB.Users.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace API_GruasUCAB.Users.Infrastructure.Configuration
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
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

            builder.Property(a => a.CedulaExpirationDate)
                .HasConversion(
                    cedulaExpirationDate => cedulaExpirationDate.Value.ToString("dd-MM-yyyy"),
                    str => new UserCedulaExpirationDate(str)
                )
                .IsRequired();

            builder.Property(a => a.MedicalCertificate)
                .HasConversion(
                    medicalCertificate => medicalCertificate.Value,
                    str => new UserMedicalCertificate(str)
                )
                .IsRequired();

            builder.Property(a => a.MedicalCertificateExpirationDate)
                .HasConversion(
                    medicalCertificateExpirationDate => medicalCertificateExpirationDate.Value.ToString("dd-MM-yyyy"),
                    str => new UserMedicalCertificateExpirationDate(str)
                )
                .IsRequired();

            builder.Property(a => a.DriverLicense)
                .HasConversion(
                    driverLicense => driverLicense.Value,
                    str => new UserDriverLicense(str)
                )
                .IsRequired();

            builder.Property(a => a.DriverLicenseExpirationDate)
                .HasConversion(
                    driverLicenseExpirationDate => driverLicenseExpirationDate.Value.ToString("dd-MM-yyyy"),
                    str => new UserDriverLicenseExpirationDate(str)
                )
                .IsRequired();

        }
    }
}