namespace API_GruasUCAB.Vehicle.Domain.ValueObject
{
     public class VehicleModel : ValueObject<VehicleModel>
     {
          public string Model { get; }

          public VehicleModel(string model)
          {
               if (string.IsNullOrWhiteSpace(model))
                    throw new InvalidVehicleModelException();

               Model = model;
          }

          public string Value => Model;

          public override bool Equals(VehicleModel other)
          {
               return Model == other.Model;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Model;
          }

          public override string ToString()
          {
               return Model;
          }
     }
}