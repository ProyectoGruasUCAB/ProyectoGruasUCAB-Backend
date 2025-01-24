namespace API_GruasUCAB.ServiceOrder.Domain.ValueObject
{
     public class IncidentDistance : ValueObject<IncidentDistance>
     {
          public float Distance { get; }

          public float Value => Distance;

          public IncidentDistance(float distance)
          {
               if (distance <= 0)
                    throw new InvalidIncidentDistanceException();

               Distance = distance;
          }

          public override bool Equals(IncidentDistance other)
          {
               return Distance == other.Distance;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Distance;
          }

          public override string ToString()
          {
               return Distance.ToString();
          }
     }
}