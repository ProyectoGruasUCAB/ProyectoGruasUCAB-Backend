namespace API_GruasUCAB.Policy.Application.Exceptions
{
     public class PolicyNotFoundException : Exception
     {
          public PolicyNotFoundException(Guid PolicyId)
              : base($"Policy with ID {PolicyId} not found.")
          {
          }
     }
}