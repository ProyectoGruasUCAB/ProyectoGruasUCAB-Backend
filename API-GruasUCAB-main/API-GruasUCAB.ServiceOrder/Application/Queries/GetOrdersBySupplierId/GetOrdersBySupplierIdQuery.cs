namespace API_GruasUCAB.ServiceOrder.Application.Queries.GetOrdersBySupplierId
{
     public class GetOrdersBySupplierIdQuery : IRequest<GetOrdersBySupplierIdResponseDTO>
     {
          public Guid SupplierId { get; set; }

          public GetOrdersBySupplierIdQuery(Guid supplierId)
          {
               SupplierId = supplierId;
          }
     }
}