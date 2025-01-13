namespace API_GruasUCAB.Vehicle.Domain.ValueObject
{
     public class VehicleColor : ValueObject<VehicleColor>
     {
          public string Color { get; }

          public VehicleColor(string color)
          {
               if (string.IsNullOrWhiteSpace(color))
                    throw new InvalidVehicleColorException();

               Color = color;
          }

          public string Value => Color;

          public override bool Equals(VehicleColor other)
          {
               return Color == other.Color;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Color;
          }

          public override string ToString()
          {
               return Color;
          }
     }
}