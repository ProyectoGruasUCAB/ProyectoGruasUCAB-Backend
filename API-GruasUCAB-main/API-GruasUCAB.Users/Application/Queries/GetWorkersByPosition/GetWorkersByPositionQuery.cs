namespace API_GruasUCAB.Users.Application.Queries.GetWorkersByPosition
{
     public class GetWorkersByPositionQuery : IRequest<GetWorkersByPositionResponseDTO>
     {
          public Guid UserId { get; set; }
          public string Position { get; set; }

          public GetWorkersByPositionQuery(Guid userId, string position)
          {
               UserId = userId;
               Position = position;
          }
     }
}