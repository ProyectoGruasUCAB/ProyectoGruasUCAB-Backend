namespace API_GruasUCAB.ServiceOrder.Domain.ValueObject
{
     public class IncidentDescription : ValueObject<IncidentDescription>
     {
          public string Description { get; }

          public string Value => Description;

          public IncidentDescription(string description)
          {
               if (string.IsNullOrWhiteSpace(description) || description.Length < 4 || description.Length > 50)
                    throw new InvalidIncidentDescriptionException();

               Description = description;
          }

          public override bool Equals(IncidentDescription other)
          {
               return Description == other.Description;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Description;
          }

          public override string ToString()
          {
               return Description;
          }
     }
}