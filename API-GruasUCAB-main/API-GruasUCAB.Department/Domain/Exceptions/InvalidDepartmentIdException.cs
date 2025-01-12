using API_GruasUCAB.Core.Domain.DomainException;

namespace API_GruasUCAB.Department.Domain.Exceptions
{
     public class InvalidDepartmentIdException : DomainException
     {
          public InvalidDepartmentIdException()
              : base("Invalid department ID")
          {
          }
     }
}