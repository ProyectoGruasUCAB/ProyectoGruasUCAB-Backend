namespace API_GruasUCAB.Supplier.Domain.ValueObject
{
     public class SupplierId : ValueObject<SupplierId>
     {
          public Guid Id { get; }

          public SupplierId(Guid id)
          {
               if (id == Guid.Empty)
                    throw new InvalidSupplierIdException();

               Id = id;
          }

          public Guid Value => Id;

          public override bool Equals(SupplierId other)
          {
               return Id == other.Id;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Id;
          }

          public override string ToString()
          {
               return Id.ToString();
          }
     }
}