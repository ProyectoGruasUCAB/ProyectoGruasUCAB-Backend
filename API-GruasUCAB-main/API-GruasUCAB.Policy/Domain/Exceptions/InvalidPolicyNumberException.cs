namespace API_GruasUCAB.Policy.Domain.Exceptions
{
     public class InvalidPolicyNumberException : Exception
     {
          public InvalidPolicyNumberException(string message) : base(message) { }
     }
}