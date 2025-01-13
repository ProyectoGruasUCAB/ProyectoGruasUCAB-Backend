namespace API_GruasUCAB.Supplier.Domain.ValueObject
{
     public class SupplierType : ValueObject<SupplierType>
     {
          public SupplierTypeEnum Type { get; }

          public SupplierType(SupplierTypeEnum type)
          {
               if (!IsValid(type))
                    throw new InvalidSupplierTypeException();

               Type = type;
          }

          public SupplierTypeEnum Value => Type;

          public override bool Equals(SupplierType other)
          {
               return Type == other.Type;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Type;
          }

          private static bool IsValid(SupplierTypeEnum type)
          {
               return Enum.IsDefined(typeof(SupplierTypeEnum), type);
          }

          public override string ToString()
          {
               return Type.ToString();
          }
     }

     public enum SupplierTypeEnum
     {
          Externo,
          Interno
     }
}