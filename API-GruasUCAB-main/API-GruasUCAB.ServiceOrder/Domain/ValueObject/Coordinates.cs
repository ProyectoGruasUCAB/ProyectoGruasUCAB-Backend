namespace API_GruasUCAB.ServiceOrder.Domain.ValueObject
{
     public class Coordinates : ValueObject<Coordinates>
     {
          public double Latitude { get; }
          public double Longitude { get; }

          public Coordinates(double latitude, double longitude)
          {
               if (latitude < -90 || latitude > 90)
                    throw new InvalidCoordinatesException("La latitud debe estar entre -90 y 90 grados.");
               if (longitude < -180 || longitude > 180)
                    throw new InvalidCoordinatesException("La longitud debe estar entre -180 y 180 grados.");

               Latitude = latitude;
               Longitude = longitude;
          }

          public override bool Equals(Coordinates other)
          {
               return Latitude == other.Latitude && Longitude == other.Longitude;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Latitude;
               yield return Longitude;
          }

          public override string ToString()
          {
               return $"{Latitude}, {Longitude}";
          }

          public static Coordinates Parse(string value)
          {
               var parts = value.Split(',');
               if (parts.Length != 2)
                    throw new InvalidCoordinatesException("Invalid coordinate format.");

               if (!double.TryParse(parts[0], out var latitude))
                    throw new InvalidCoordinatesException("Invalid latitude.");

               if (!double.TryParse(parts[1], out var longitude))
                    throw new InvalidCoordinatesException("Invalid length.");

               return new Coordinates(latitude, longitude);
          }
     }
}