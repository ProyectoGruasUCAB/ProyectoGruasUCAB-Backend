namespace API_GruasUCAB.Supplier.Application.Queries.GetSupplierByName
{
     public class GetSupplierByNameQuery : IRequest<GetSupplierByNameResponseDTO>
     {
          public string Name { get; set; }

          public GetSupplierByNameQuery(string name)
          {
               Name = name;
          }
     }
}