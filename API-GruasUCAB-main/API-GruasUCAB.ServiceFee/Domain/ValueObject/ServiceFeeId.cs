namespace API_GruasUCAB.ServiceFee.Domain.ValueObject
{
     public class ServiceFeeId : ValueObject<ServiceFeeId>
     {
          public Guid Id { get; }

          public ServiceFeeId(Guid id)
          {
               if (id == Guid.Empty)
                    throw new InvalidServiceFeeIdException();

               Id = id;
          }

          public ServiceFeeId(string id)
          {
               if (!Guid.TryParse(id, out Guid parsedId) || parsedId == Guid.Empty)
                    throw new InvalidServiceFeeIdException();

               Id = parsedId;
          }

          public Guid Value => Id;

          public override bool Equals(ServiceFeeId other)
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