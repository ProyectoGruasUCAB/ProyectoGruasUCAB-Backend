namespace API_GruasUCAB.Policy.Domain.ValueObject
{
     public class PolicyNumber : ValueObject<PolicyNumber>
     {
          public string Number { get; }

          public PolicyNumber(string number)
          {
               if (string.IsNullOrWhiteSpace(number))
                    throw new InvalidPolicyNumberException("Policy number cannot be empty.");

               // Si el número de póliza debe ser estrictamente numérico, descomenta la siguiente línea
               // if (!number.All(char.IsDigit))
               //     throw new InvalidPolicyNumberException("Policy number must be numeric.");

               Number = number;
          }

          public string Value => Number;

          public override bool Equals(PolicyNumber other)
          {
               return Number == other.Number;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Number;
          }

          public override string ToString()
          {
               return Number;
          }
     }
}