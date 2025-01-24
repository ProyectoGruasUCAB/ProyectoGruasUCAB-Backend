namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserRolesException : Exception
     {
          public InvalidUserRolesException(string role)
              : base($"Invalid user role: {role}")
          {
          }
     }
}