namespace API_GruasUCAB.Vehicle.Domain.Entity
{
     public class VehicleType : Entity<VehicleTypeId>
     {
          public VehicleTypeEnumerate Type { get; private set; }
          public string DescripcionVehicleType { get; private set; }

          public VehicleType(VehicleTypeId id, VehicleTypeEnumerate type, string descripcionVehicleType)
              : base(id)
          {
               Type = type;
               DescripcionVehicleType = descripcionVehicleType ?? throw new ArgumentNullException(nameof(descripcionVehicleType), "Vehicle type must have a description.");
          }

          public void ChangeType(VehicleTypeEnumerate newType)
          {
               Type = newType;
          }

          public void ChangeDescripcionVehicleType(string newDescripcion)
          {
               if (string.IsNullOrWhiteSpace(newDescripcion))
                    throw new ArgumentNullException(nameof(newDescripcion), "New description cannot be null or empty.");
               DescripcionVehicleType = newDescripcion;
          }
     }

     public enum VehicleTypeEnumerate
     {
          Arrastre,
          Plataforma,
          Telescopicas,
          Horquilla,
          Autopropulsadas,
          Torre
     }
}