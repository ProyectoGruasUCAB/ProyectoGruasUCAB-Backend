namespace API_GruasUCAB.Vehicle.Application.Queries.GetAllVehicles
{
     public class GetAllVehiclesQuery : IRequest<GetAllVehiclesResponseDTO>
     {
          public Guid UserId { get; set; }

          public GetAllVehiclesQuery(Guid userId)
          {
               UserId = userId;
          }
     }
}