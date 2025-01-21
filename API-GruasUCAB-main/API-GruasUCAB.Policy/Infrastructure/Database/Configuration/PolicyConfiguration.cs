using API_GruasUCAB.Policy.Domain.Entities;

namespace API_GruasUCAB.Policy.Infrastructure.Database.Configuration
{
    public class PolicyConfiguration : IEntityTypeConfiguration<API_GruasUCAB.Policy.Domain.AggregateRoot.Policy>
    {
        public void Configure(EntityTypeBuilder<API_GruasUCAB.Policy.Domain.AggregateRoot.Policy> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value.ToString(), str => new PolicyId(Guid.Parse(str)))
                .IsRequired();

            builder.Property(p => p.Number)
                .HasConversion(number => number.Value, str => new PolicyNumber(str))
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Name)
                .HasConversion(name => name.Value, str => new PolicyName(str))
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.IssueDate)
                .HasConversion(
                    issueDate => issueDate.Value.ToString("dd-MM-yyyy"),
                    str => new PolicyIssueDate(str)
                )
                .IsRequired();

            builder.Property(p => p.ExpirationDate)
                .HasConversion(
                    expirationDate => expirationDate.Value.ToString("dd-MM-yyyy"),
                    str => new PolicyExpirationDate(str, DateTime.ParseExact(str, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                )
                .IsRequired();

            builder.Property(p => p.CoverageKm)
                .HasConversion(coverageKm => coverageKm.Value, str => new PolicyCoverageKm(str))
                .IsRequired();

            builder.Property(p => p.CoverageAmount)
                .HasConversion(coverageAmount => coverageAmount.Value, str => new PolicyCoverageAmount(str))
                .IsRequired();

            builder.Property(p => p.BaseAmount)
                .HasConversion(baseAmount => baseAmount.Value, str => new PolicyBaseAmount(str))
                .IsRequired();

            builder.Property(p => p.PriceKm)
                .HasConversion(priceKm => priceKm.Value, str => new PolicyPriceKm(str))
                .IsRequired();

            builder.Property(p => p.ClientId)
                .HasConversion(clientId => clientId.Value.ToString(), str => new ClientId(Guid.Parse(str)))
                .IsRequired();
        }
    }
}
