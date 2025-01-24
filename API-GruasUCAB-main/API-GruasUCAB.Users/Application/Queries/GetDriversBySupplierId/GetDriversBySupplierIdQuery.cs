namespace API_GruasUCAB.Users.Application.Queries.GetDriversBySupplierId
{
     public class GetDriversBySupplierIdQuery : IRequest<GetDriversBySupplierIdResponseDTO>
     {
          public Guid SupplierId { get; set; }

          public GetDriversBySupplierIdQuery(Guid supplierId)
          {
               SupplierId = supplierId;
          }
     }
}