namespace API_GruasUCAB.Department.Domain.Exceptions
{
     public class InvalidDepartmentDescriptionException : DomainException
     {
          public InvalidDepartmentDescriptionException()
              : base("Invalid department description")
          {
          }
     }
}