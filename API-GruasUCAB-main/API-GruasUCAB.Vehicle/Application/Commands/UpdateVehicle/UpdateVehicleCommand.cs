namespace API_GruasUCAB.Vehicle.Application.Commands.UpdateVehicle
{
     public class UpdateVehicleCommand : IRequest<UpdateVehicleResponseDTO>
     {
          public UpdateVehicleRequestDTO UpdateVehicleRequestDTO { get; set; }

          public UpdateVehicleCommand(UpdateVehicleRequestDTO updateVehicleRequestDTO)
          {
               UpdateVehicleRequestDTO = updateVehicleRequestDTO;
          }
     }
}