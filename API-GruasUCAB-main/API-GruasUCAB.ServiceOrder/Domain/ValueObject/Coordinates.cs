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
     }
}