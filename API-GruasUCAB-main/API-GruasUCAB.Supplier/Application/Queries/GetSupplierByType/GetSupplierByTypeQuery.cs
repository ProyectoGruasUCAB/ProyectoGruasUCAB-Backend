namespace API_GruasUCAB.Supplier.Application.Queries.GetSupplierByType
{
     public class GetSupplierByTypeQuery : IRequest<GetSupplierByTypeResponseDTO>
     {
          public Guid UserId { get; set; }
          public string Type { get; set; }

          public GetSupplierByTypeQuery(Guid userId, string type)
          {
               UserId = userId;
               Type = type;
          }
     }
}