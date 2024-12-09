namespace API_GruasUCAB.Core.Domain.DomainException
{
     public abstract class DomainException : Exception
     {
          protected DomainException(string message) : base(message)
          {
          }

          public override string ToString()
          {
               return $"{GetType().Name}: {Message}";
          }
     }
}