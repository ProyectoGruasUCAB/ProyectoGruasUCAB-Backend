namespace API_GruasUCAB.Vehicle.Domain.ValueObject
{
     public class VehicleTypeId : ValueObject<VehicleTypeId>
     {
          public Guid Id { get; }

          public VehicleTypeId(Guid id)
          {
               if (id == Guid.Empty)
                    throw new InvalidVehicleTypeIdException();

               Id = id;
          }

          public VehicleTypeId(string id)
          {
               if (!Guid.TryParse(id, out Guid parsedId) || parsedId == Guid.Empty)
                    throw new InvalidVehicleTypeIdException();

               Id = parsedId;
          }

          public Guid Value => Id;

          public override bool Equals(VehicleTypeId other)
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