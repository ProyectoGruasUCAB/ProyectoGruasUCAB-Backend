namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserBirthDateException : Exception
     {
          public InvalidUserBirthDateException(DateTime birthDate)
              : base($"Invalid birth date: {birthDate.ToString("dd-MM-yyyy")}")
          {
          }
     }
}