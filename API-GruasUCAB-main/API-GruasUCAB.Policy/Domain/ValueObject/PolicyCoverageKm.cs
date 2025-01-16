namespace API_GruasUCAB.Policy.Domain.ValueObject
{
     public class PolicyCoverageKm : ValueObject<PolicyCoverageKm>
     {
          public int CoverageKm { get; }

          public PolicyCoverageKm(int coverageKm)
          {
               if (coverageKm <= 0)
                    throw new InvalidPolicyCoverageKmException();

               CoverageKm = coverageKm;
          }

          public int Value => CoverageKm;

          public override bool Equals(PolicyCoverageKm other)
          {
               return CoverageKm == other.CoverageKm;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return CoverageKm;
          }

          public override string ToString()
          {
               return CoverageKm.ToString();
          }
     }
}