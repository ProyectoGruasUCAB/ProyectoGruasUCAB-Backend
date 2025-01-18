namespace API_GruasUCAB.ServiceOrder.Domain.ValueObject
{
     public class CustomerVehicleDescription : ValueObject<CustomerVehicleDescription>
     {
          public string Description { get; }

          public string Value => Description;

          public CustomerVehicleDescription(string description)
          {
               if (string.IsNullOrWhiteSpace(description) || description.Length < 4 || description.Length > 50)
                    throw new InvalidCustomerVehicleDescriptionException();

               Description = description;
          }

          public override bool Equals(CustomerVehicleDescription other)
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