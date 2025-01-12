namespace API_GruasUCAB.Department.Domain.ValueObject
{
     public class DepartmentId : ValueObject<DepartmentId>
     {
          public Guid Id { get; }

          public DepartmentId(Guid id)
          {
               if (id == Guid.Empty)
                    throw new InvalidDepartmentIdException();

               Id = id;
          }

          public Guid Value => Id;

          public override bool Equals(DepartmentId other)
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