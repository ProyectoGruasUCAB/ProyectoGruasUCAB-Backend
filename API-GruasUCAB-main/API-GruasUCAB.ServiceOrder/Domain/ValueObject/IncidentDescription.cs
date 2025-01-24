namespace API_GruasUCAB.ServiceOrder.Domain.ValueObject
{
     public class IncidentDescription : ValueObject<IncidentDescription>
     {
          public string Description { get; }

          public string Value => Description;

          public IncidentDescription(string description)
          {
               description = description.Trim();
               if (string.IsNullOrWhiteSpace(description))
                    throw new InvalidIncidentDescriptionException("Description cannot be null or whitespace.");

               if (description.Length < 4)
                    throw new InvalidIncidentDescriptionException("Description must be at least 4 characters long.");

               if (description.Length > 50)
                    throw new InvalidIncidentDescriptionException("Description cannot be more than 50 characters long.");

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