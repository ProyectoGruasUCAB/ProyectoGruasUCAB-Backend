namespace API_GruasUCAB.Users.Domain.Exceptions
{
     public class InvalidUserPhoneException : Exception
     {
          public InvalidUserPhoneException(string phone)
              : base($"Invalid phone number: {phone}")
          {
          }
     }
}