namespace API_GruasUCAB.Vehicle.Domain.ValueObject
{
     public class VehicleId : ValueObject<VehicleId>
     {
          public Guid Id { get; }

          public VehicleId(Guid id)
          {
               if (id == Guid.Empty)
                    throw new InvalidVehicleIdException();

               Id = id;
          }

          public VehicleId(string id)
          {
               if (!Guid.TryParse(id, out Guid parsedId) || parsedId == Guid.Empty)
                    throw new InvalidVehicleIdException();

               Id = parsedId;
          }

          public Guid Value => Id;

          public override bool Equals(VehicleId other)
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