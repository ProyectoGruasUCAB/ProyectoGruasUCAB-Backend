using API_GruasUCAB.Core.Domain.DomainException;

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