namespace API_GruasUCAB.ServiceFee.Domain.ValueObject
{
     public class ServiceFeeDescription : ValueObject<ServiceFeeDescription>
     {
          public string Description { get; }

          public ServiceFeeDescription(string description)
          {
               if (string.IsNullOrWhiteSpace(description) || description.Length < 5 || description.Length > 100)
                    throw new InvalidServiceFeeDescriptionException();

               Description = description;
          }

          public string Value => Description;

          public override bool Equals(ServiceFeeDescription other)
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