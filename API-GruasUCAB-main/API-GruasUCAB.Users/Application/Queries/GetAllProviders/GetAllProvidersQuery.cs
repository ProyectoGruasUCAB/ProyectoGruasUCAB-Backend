namespace API_GruasUCAB.Users.Application.Queries.GetAllProviders
{
     public class GetAllProvidersQuery : IRequest<GetAllProvidersResponseDTO>
     {
          public Guid UserId { get; set; }

          public GetAllProvidersQuery(Guid userId)
          {
               UserId = userId;
          }
     }
}