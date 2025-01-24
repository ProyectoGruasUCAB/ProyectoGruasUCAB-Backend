namespace API_GruasUCAB.Supplier.Application.Queries.GetAllSuppliers
{
     public class GetAllSuppliersQuery : IRequest<GetAllSuppliersResponseDTO>
     {
          public Guid UserId { get; set; }

          public GetAllSuppliersQuery(Guid userId)
          {
               UserId = userId;
          }
     }
}