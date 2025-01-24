namespace API_GruasUCAB.Users.Application.Queries.GetDriverById
{
     public class GetDriverByIdQuery : IRequest<GetDriverByIdResponseDTO>
     {
          public Guid UserId { get; set; }
          public Guid DriverId { get; set; }

          public GetDriverByIdQuery(Guid userId, Guid driverId)
          {
               UserId = userId;
               DriverId = driverId;
          }
     }
}