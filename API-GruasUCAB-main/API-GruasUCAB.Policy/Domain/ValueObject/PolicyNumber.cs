namespace API_GruasUCAB.Policy.Domain.ValueObject
{
     public class PolicyNumber : ValueObject<PolicyNumber>
     {
          public string Number { get; }

          public PolicyNumber(string number)
          {
               if (string.IsNullOrWhiteSpace(number) || !number.All(char.IsDigit))
                    throw new InvalidPolicyNumberException();

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