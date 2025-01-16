namespace API_GruasUCAB.Policy.Domain.AggregateRoot
{
     public class Policy : AggregateRoot<PolicyId>
     {
          public PolicyNumber PolicyNumber { get; private set; }
          public PolicyName PolicyName { get; private set; }
          public PolicyCoverageAmount PolicyCoverageAmount { get; private set; }
          public PolicyCoverageKm PolicyCoverageKm { get; private set; }
          public PolicyBaseAmount PolicyBaseAmount { get; private set; }
          public PolicyPriceKm PolicyPriceKm { get; private set; }
          public PolicyIssueDate PolicyIssueDate { get; private set; }
          public PolicyExpirationDate PolicyExpirationDate { get; private set; }
          public PolicyClient PolicyClient { get; private set; }

          public Policy(
              PolicyId policyId,
              PolicyNumber policyNumber,
              PolicyName policyName,
              PolicyCoverageAmount policyCoverageAmount,
              PolicyCoverageKm policyCoverageKm,
              PolicyBaseAmount policyBaseAmount,
              PolicyPriceKm policyPriceKm,
              PolicyIssueDate policyIssueDate,
              PolicyExpirationDate policyExpirationDate,
              PolicyClient policyClient) : base(policyId)
          {
               PolicyNumber = policyNumber ?? throw new ArgumentNullException(nameof(policyNumber));
               PolicyName = policyName ?? throw new ArgumentNullException(nameof(policyName));
               PolicyCoverageAmount = policyCoverageAmount ?? throw new ArgumentNullException(nameof(policyCoverageAmount));
               PolicyCoverageKm = policyCoverageKm ?? throw new ArgumentNullException(nameof(policyCoverageKm));
               PolicyBaseAmount = policyBaseAmount ?? throw new ArgumentNullException(nameof(policyBaseAmount));
               PolicyPriceKm = policyPriceKm ?? throw new ArgumentNullException(nameof(policyPriceKm));
               PolicyIssueDate = policyIssueDate ?? throw new ArgumentNullException(nameof(policyIssueDate));
               PolicyExpirationDate = policyExpirationDate ?? throw new ArgumentNullException(nameof(policyExpirationDate));
               PolicyClient = policyClient ?? throw new ArgumentNullException(nameof(policyClient));

               ValidateState();
               AddDomainEvent(new PolicyCreatedEvent(policyId, policyNumber, policyName, policyCoverageAmount, policyCoverageKm, policyBaseAmount, policyPriceKm, policyIssueDate, policyExpirationDate, policyClient));
          }

          protected override void ValidateState()
          {
               ValidatePolicyNumber();
               ValidatePolicyName();
               ValidatePolicyCoverageAmount();
               ValidatePolicyCoverageKm();
               ValidatePolicyBaseAmount();
               ValidatePolicyPriceKm();
               ValidatePolicyIssueDate();
               ValidatePolicyExpirationDate();
               ValidatePolicyClient();
          }

          private void ValidatePolicyNumber()
          {
               if (PolicyNumber == null)
                    throw new InvalidPolicyNumberException();
          }

          private void ValidatePolicyName()
          {
               if (PolicyName == null)
                    throw new InvalidPolicyNameException();
          }

          private void ValidatePolicyCoverageAmount()
          {
               if (PolicyCoverageAmount == null)
                    throw new InvalidPolicyCoverageAmountException();
          }

          private void ValidatePolicyCoverageKm()
          {
               if (PolicyCoverageKm == null)
                    throw new InvalidPolicyCoverageKmException();
          }

          private void ValidatePolicyBaseAmount()
          {
               if (PolicyBaseAmount == null)
                    throw new InvalidPolicyBaseAmountException();
          }

          private void ValidatePolicyPriceKm()
          {
               if (PolicyPriceKm == null)
                    throw new InvalidPolicyPriceKmException();
          }

          private void ValidatePolicyIssueDate()
          {
               if (PolicyIssueDate == null)
                    throw new InvalidPolicyIssueDateFormatException("Issue date is null");
          }

          private void ValidatePolicyExpirationDate()
          {
               if (PolicyExpirationDate == null)
                    throw new InvalidPolicyExpirationDateFormatException("Expiration date is null");
          }

          private void ValidatePolicyClient()
          {
               if (PolicyClient == null)
                    throw new InvalidPolicyClientIdException();
          }
     }
}