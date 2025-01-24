namespace API_GruasUCAB.Vehicle.Application.Queries.GetVehiclesBySupplierId
{
     public class GetVehiclesBySupplierIdQuery : IRequest<GetVehiclesBySupplierIdResponseDTO>
     {
          public Guid SupplierId { get; set; }

          public GetVehiclesBySupplierIdQuery(Guid supplierId)
          {
               SupplierId = supplierId;
          }
     }
}