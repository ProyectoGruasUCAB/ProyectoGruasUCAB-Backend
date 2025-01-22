namespace API_GruasUCAB.Vehicle.Application.Commands.UpdateVehicleType
{
     public class UpdateVehicleTypeCommand : IRequest<UpdateVehicleTypeResponseDTO>
     {
          public UpdateVehicleTypeRequestDTO UpdateVehicleTypeRequestDTO { get; set; }

          public UpdateVehicleTypeCommand(UpdateVehicleTypeRequestDTO updateVehicleTypeRequestDTO)
          {
               UpdateVehicleTypeRequestDTO = updateVehicleTypeRequestDTO;
          }
     }
}