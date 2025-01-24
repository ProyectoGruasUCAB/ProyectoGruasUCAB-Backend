namespace API_GruasUCAB.Users.Application.Queries.GetAllDrivers
{
     public class GetAllDriversQuery : IRequest<GetAllDriversResponseDTO>
     {
          public Guid UserId { get; set; }

          public GetAllDriversQuery(Guid userId)
          {
               UserId = userId;
          }
     }
}