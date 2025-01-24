namespace API_GruasUCAB.ServiceOrder.Domain.ValueObject
{
     public class ServiceOrderId : ValueObject<ServiceOrderId>
     {
          public Guid Id { get; }

          public ServiceOrderId(Guid id)
          {
               if (id == Guid.Empty)
                    throw new InvalidServiceOrderIdException();

               Id = id;
          }

          public ServiceOrderId(string id)
          {
               if (!Guid.TryParse(id, out Guid parsedId) || parsedId == Guid.Empty)
                    throw new InvalidServiceOrderIdException();

               Id = parsedId;
          }

          public Guid Value => Id;

          public override bool Equals(ServiceOrderId other)
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