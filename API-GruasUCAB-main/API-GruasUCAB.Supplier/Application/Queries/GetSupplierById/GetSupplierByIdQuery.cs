namespace API_GruasUCAB.Supplier.Application.Queries.GetSupplierById
{
     public class GetSupplierByIdQuery : IRequest<GetSupplierByIdResponseDTO>
     {
          public Guid UserId { get; set; }
          public Guid SupplierId { get; set; }

          public GetSupplierByIdQuery(Guid userId, Guid supplierId)
          {
               UserId = userId;
               SupplierId = supplierId;
          }
     }
}