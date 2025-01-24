namespace API_GruasUCAB.Users.Application.Queries.GetWorkersByName
{
     public class GetWorkersByNameQuery : IRequest<GetWorkersByNameResponseDTO>
     {
          public Guid UserId { get; set; }
          public string Name { get; set; }

          public GetWorkersByNameQuery(Guid userId, string name)
          {
               UserId = userId;
               Name = name;
          }
     }
}