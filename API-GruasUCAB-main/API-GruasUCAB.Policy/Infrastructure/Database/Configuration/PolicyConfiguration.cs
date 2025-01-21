global using PolicyAggregate = API_GruasUCAB.Policy.Domain.AggregateRoot.Policy;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace API_GruasUCAB.Policy.Infrastructure.Database.Configuration
{
    public class PolicyConfiguration : IEntityTypeConfiguration<PolicyAggregate>
    {
        public void Configure(EntityTypeBuilder<PolicyAggregate> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value.ToString(), str => new PolicyId(Guid.Parse(str)))
                .IsRequired();

            builder.Property(p => p.PolicyNumber)
                .HasConversion(number => number.Value, str => new PolicyNumber(str))
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.PolicyName)
                .HasConversion(name => name.Value, str => new PolicyName(str))
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.PolicyIssueDate)
                .HasConversion(
                    issueDate => issueDate.Value.ToString("dd-MM-yyyy"),
                    str => new PolicyIssueDate(DateTime.ParseExact(str, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                )
                .IsRequired();

            builder.Property(p => p.PolicyExpirationDate)
                .HasConversion(
                    expirationDate => expirationDate.Value.ToString("dd-MM-yyyy"),
                    str => new PolicyExpirationDate(DateTime.ParseExact(str, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                )
                .IsRequired();

            builder.Property(p => p.PolicyCoverageKm)
                .HasConversion(coverageKm => coverageKm.Value, value => new PolicyCoverageKm(value))
                .IsRequired();

            builder.Property(p => p.PolicyCoverageAmount)
                .HasConversion(coverageAmount => coverageAmount.Value, value => new PolicyCoverageAmount(value))
                .IsRequired();

            builder.Property(p => p.PolicyBaseAmount)
                .HasConversion(baseAmount => baseAmount.Value, value => new PolicyBaseAmount(value))
                .IsRequired();

            builder.Property(p => p.PolicyPriceKm)
                .HasConversion(priceKm => priceKm.Value, value => new PolicyPriceKm(value))
                .IsRequired();

            builder.Property(p => p.PolicyClient)
                .HasConversion(clientId => clientId.Value.ToString(), str => new PolicyClient(Guid.Parse(str)))
                .IsRequired();
        }
    }
}
