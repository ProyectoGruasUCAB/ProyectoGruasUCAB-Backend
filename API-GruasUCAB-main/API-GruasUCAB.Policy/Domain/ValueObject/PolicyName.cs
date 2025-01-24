namespace API_GruasUCAB.Policy.Domain.ValueObject
{
     public class PolicyName : ValueObject<PolicyName>
     {
          public string Name { get; }

          public PolicyName(string name)
          {
               if (string.IsNullOrWhiteSpace(name) || name.Length < 4)
                    throw new InvalidPolicyNameException();

               Name = name;
          }

          public string Value => Name;

          public override bool Equals(PolicyName other)
          {
               return Name == other.Name;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Name;
          }

          public override string ToString()
          {
               return Name;
          }
     }
}