global using PolicyAggregate = API_GruasUCAB.Policy.Domain.AggregateRoot.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_GruasUCAB.Policy.Infrastructure.Database.Configuration
{
    public class PolicyConfiguration : IEntityTypeConfiguration<PolicyAggregate>
    {
        public void Configure(EntityTypeBuilder<PolicyAggregate> builder)
        {
            builder.HasKey(cd => cd.Id);

            builder.Property(cd => cd.Id)
                .HasConversion(id => id.Value.ToString(), str => new PolicyId(Guid.Parse(str)))
                .IsRequired();

            builder.Property(cd => cd.PolicyNumber)
                .HasConversion(number => number.Value, str => new PolicyNumber(str))
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cd => cd.PolicyName)
                .HasConversion(name => name.Value, str => new PolicyName(str))
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(cd => cd.PolicyIssueDate)
                .HasConversion(
                    issueDate => issueDate.Value.ToString("dd-MM-yyyy"),
                    str => new PolicyIssueDate(str)
                )
                .IsRequired();

            builder.Property(cd => cd.PolicyExpirationDate)
                .HasConversion(
                    expirationDate => expirationDate.Value.ToString("dd-MM-yyyy"),
                    str => new PolicyExpirationDate(str, DateTime.Now)
                )
                .IsRequired();

            builder.Property(cd => cd.PolicyCoverageKm)
                .HasConversion(coverageKm => coverageKm.Value, value => new PolicyCoverageKm(value))
                .IsRequired();

            builder.Property(cd => cd.PolicyCoverageAmount)
                .HasConversion(coverageAmount => coverageAmount.Value, value => new PolicyCoverageAmount(value))
                .IsRequired();

            builder.Property(cd => cd.PolicyBaseAmount)
                .HasConversion(baseAmount => baseAmount.Value, value => new PolicyBaseAmount(value))
                .IsRequired();

            builder.Property(cd => cd.PolicyPriceKm)
                .HasConversion(priceKm => priceKm.Value, value => new PolicyPriceKm(value))
                .IsRequired();

            builder.Property(cd => cd.PolicyClient)
                .HasConversion(clientId => clientId.Value.ToString(), str => new PolicyClient(Guid.Parse(str)))
                .IsRequired();
        }
    }
}
