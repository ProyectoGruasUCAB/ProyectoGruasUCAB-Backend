namespace API_GruasUCAB.Users.Application.Queries.GetProviderById
{
     public class GetProviderByIdQuery : IRequest<GetProviderByIdResponseDTO>
     {
          public Guid UserId { get; set; }
          public Guid ProviderId { get; set; }

          public GetProviderByIdQuery(Guid userId, Guid providerId)
          {
               UserId = userId;
               ProviderId = providerId;
          }
     }
}