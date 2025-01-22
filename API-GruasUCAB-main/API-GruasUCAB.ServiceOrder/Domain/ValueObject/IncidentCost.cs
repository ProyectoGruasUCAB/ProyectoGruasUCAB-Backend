namespace API_GruasUCAB.ServiceOrder.Domain.ValueObject
{
     public class IncidentCost : ValueObject<IncidentCost>
     {
          public decimal Cost { get; }

          public decimal Value => Cost;

          public IncidentCost(decimal cost)
          {
               if (cost < 0)
                    throw new InvalidIncidentCostException();

               Cost = cost;
          }

          public override bool Equals(IncidentCost other)
          {
               return Cost == other.Cost;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Cost;
          }

          public override string ToString()
          {
               return Cost.ToString();
          }
     }
}