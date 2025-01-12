namespace API_GruasUCAB.Department.Domain.ValueObject
{
     public class DepartmentDescription : ValueObject<DepartmentDescription>
     {
          public string Description { get; }

          public DepartmentDescription(string description)
          {
               if (string.IsNullOrWhiteSpace(description) || description.Length < 10 || description.Length > 50)
                    throw new InvalidDepartmentDescriptionException();

               Description = description;
          }

          public string Value => Description;

          public override bool Equals(DepartmentDescription other)
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