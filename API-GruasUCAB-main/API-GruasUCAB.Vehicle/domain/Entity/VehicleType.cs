namespace API_GruasUCAB.Vehicle.Domain.Entity
{
     public class VehicleType : Entity<VehicleTypeId>
     {
          public VehicleTypeEnumerate Type { get; private set; }
          public DescripcionVehicleType DescripcionVehicleType { get; private set; }

          public VehicleType(VehicleTypeId id, VehicleTypeEnumerate type, DescripcionVehicleType descripcionVehicleType)
              : base(id)
          {
               Type = type;
               DescripcionVehicleType = descripcionVehicleType ?? throw new ArgumentNullException(nameof(descripcionVehicleType), "Vehicle type must have a description.");
          }

          public void ChangeType(VehicleTypeEnumerate newType)
          {
               Type = newType;
          }

          public void ChangeDescripcionVehicleType(DescripcionVehicleType newDescripcion)
          {
               DescripcionVehicleType = newDescripcion ?? throw new ArgumentNullException(nameof(newDescripcion), "New description cannot be null or empty.");
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