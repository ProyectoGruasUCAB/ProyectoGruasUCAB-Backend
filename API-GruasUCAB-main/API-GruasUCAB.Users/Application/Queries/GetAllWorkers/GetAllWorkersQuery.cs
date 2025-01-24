namespace API_GruasUCAB.Users.Application.Queries.GetAllWorkers
{
     public class GetAllWorkersQuery : IRequest<GetAllWorkersResponseDTO>
     {
          public Guid UserId { get; set; }

          public GetAllWorkersQuery(Guid userId)
          {
               UserId = userId;
          }
     }
}