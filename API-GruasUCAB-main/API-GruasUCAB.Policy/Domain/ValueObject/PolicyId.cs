namespace API_GruasUCAB.Policy.Domain.ValueObject
{
     public class PolicyId : ValueObject<PolicyId>
     {
          public Guid Id { get; }

          public PolicyId(Guid id)
          {
               if (id == Guid.Empty)
                    throw new InvalidPolicyIdException();

               Id = id;
          }

          public PolicyId(string id)
          {
               if (!Guid.TryParse(id, out Guid parsedId) || parsedId == Guid.Empty)
                    throw new InvalidPolicyIdException();

               Id = parsedId;
          }

          public Guid Value => Id;

          public override bool Equals(PolicyId other)
          {
               return Id == other.Id;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Id;
          }

          public override string ToString()
          {
               return Id.ToString();
          }
     }
}