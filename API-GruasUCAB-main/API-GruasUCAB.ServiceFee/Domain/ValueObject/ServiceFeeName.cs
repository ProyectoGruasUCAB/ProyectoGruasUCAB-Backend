namespace API_GruasUCAB.ServiceFee.Domain.ValueObject
{
     public class ServiceFeeName : ValueObject<ServiceFeeName>
     {
          public string Name { get; }

          public ServiceFeeName(string name)
          {
               if (string.IsNullOrWhiteSpace(name) || name.Length < 4)
                    throw new InvalidServiceFeeNameException();

               Name = name;
          }

          public string Value => Name;

          public override bool Equals(ServiceFeeName other)
          {
               return Name == other.Name;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Name;
          }

          public override string ToString()
          {
               return Name;
          }
     }
}