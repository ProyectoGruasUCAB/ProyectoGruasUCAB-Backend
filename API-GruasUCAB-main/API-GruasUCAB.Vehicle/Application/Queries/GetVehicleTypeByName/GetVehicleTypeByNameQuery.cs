namespace API_GruasUCAB.Vehicle.Application.Queries.GetVehicleTypeByName
{
     public class GetVehicleTypeByNameQuery : IRequest<GetVehicleTypeByNameResponseDTO>
     {
          public string Name { get; set; }

          public GetVehicleTypeByNameQuery(string name)
          {
               Name = name;
          }
     }
}