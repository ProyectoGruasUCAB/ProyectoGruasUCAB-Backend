namespace API_GruasUCAB.Policy.Domain.ValueObject
{
     public class PolicyClient : ValueObject<PolicyClient>
     {
          public Guid ClientId { get; }

          public PolicyClient(Guid clientId)
          {
               if (clientId == Guid.Empty)
                    throw new InvalidPolicyClientIdException();

               ClientId = clientId;
          }

          public PolicyClient(string clientId)
          {
               if (!Guid.TryParse(clientId, out Guid parsedId) || parsedId == Guid.Empty)
                    throw new InvalidPolicyClientIdException();

               ClientId = parsedId;
          }

          public Guid Value => ClientId;

          public override bool Equals(PolicyClient other)
          {
               return ClientId == other.ClientId;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return ClientId;
          }

          public override string ToString()
          {
               return ClientId.ToString();
          }
     }
}