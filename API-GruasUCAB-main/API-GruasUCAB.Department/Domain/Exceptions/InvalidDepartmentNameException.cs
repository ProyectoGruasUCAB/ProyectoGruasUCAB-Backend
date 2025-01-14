namespace API_GruasUCAB.Department.Domain.Exceptions
{
     public class InvalidDepartmentNameException : DomainException
     {
          public InvalidDepartmentNameException()
              : base("Invalid department name")
          {
          }
     }
}