namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidDepartmentIdException : DomainException
     {
          public InvalidDepartmentIdException()
              : base("Invalid department ID")
          {
          }
     }
}