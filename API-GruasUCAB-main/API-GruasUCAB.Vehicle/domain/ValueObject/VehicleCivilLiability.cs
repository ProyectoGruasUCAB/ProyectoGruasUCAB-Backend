namespace API_GruasUCAB.Vehicle.Domain.ValueObject
{
     public class VehicleCivilLiability : ValueObject<VehicleCivilLiability>
     {
          public string Liability { get; }

          public VehicleCivilLiability(string liability)
          {
               if (string.IsNullOrWhiteSpace(liability))
                    throw new InvalidVehicleCivilLiabilityException();

               Liability = liability;
          }

          public string Value => Liability;

          public override bool Equals(VehicleCivilLiability other)
          {
               return Liability == other.Liability;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Liability;
          }

          public override string ToString()
          {
               return Liability;
          }
     }
}