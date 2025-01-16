namespace API_GruasUCAB.Users.Application.Queries.GetProvidersByName
{
     public class GetProvidersByNameQuery : IRequest<GetProvidersByNameResponseDTO>
     {
          public Guid UserId { get; set; }
          public string Name { get; set; }

          public GetProvidersByNameQuery(Guid userId, string name)
          {
               UserId = userId;
               Name = name;
          }
     }
}