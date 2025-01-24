namespace API_GruasUCAB.Vehicle.Domain.ValueObject
{
     public class DescripcionVehicleType : ValueObject<DescripcionVehicleType>
     {
          public string Value { get; }

          public DescripcionVehicleType(string value)
          {
               if (string.IsNullOrWhiteSpace(value))
               {
                    throw new ArgumentNullException(nameof(value), "Vehicle type description cannot be null or empty.");
               }

               Value = value;
          }

          public override bool Equals(DescripcionVehicleType other)
          {
               return Value == other?.Value;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Value;
          }

          public override string ToString()
          {
               return Value;
          }
     }
}