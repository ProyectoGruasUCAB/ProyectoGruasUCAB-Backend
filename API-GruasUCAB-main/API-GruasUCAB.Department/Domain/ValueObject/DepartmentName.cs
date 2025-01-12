namespace API_GruasUCAB.Department.Domain.ValueObject
{
     public class DepartmentName : ValueObject<DepartmentName>
     {
          public string Name { get; }

          public DepartmentName(string name)
          {
               if (string.IsNullOrWhiteSpace(name) || name.Length < 4)
                    throw new InvalidDepartmentNameException();

               Name = name;
          }

          public string Value => Name;

          public override bool Equals(DepartmentName other)
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