namespace API_GruasUCAB.Supplier.Domain.ValueObject
{
     public class SupplierName : ValueObject<SupplierName>
     {
          public string Name { get; }

          public SupplierName(string name)
          {
               if (string.IsNullOrWhiteSpace(name) || name.Length < 4)
                    throw new InvalidSupplierNameException();

               Name = name;
          }

          public string Value => Name;

          public override bool Equals(SupplierName other)
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