namespace API_GruasUCAB.Users.Application.Queries.GetWorkerById
{
     public class GetWorkerByIdQuery : IRequest<GetWorkerByIdResponseDTO>
     {
          public Guid UserId { get; set; }
          public Guid WorkerId { get; set; }

          public GetWorkerByIdQuery(Guid userId, Guid workerId)
          {
               UserId = userId;
               WorkerId = workerId;
          }
     }
}