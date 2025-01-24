namespace API_GruasUCAB.Vehicle.Application.Commands.CreateVehicleType
{
     public class CreateVehicleTypeCommand : IRequest<CreateVehicleTypeResponseDTO>
     {
          public CreateVehicleTypeRequestDTO CreateVehicleTypeRequestDTO { get; set; }

          public CreateVehicleTypeCommand(CreateVehicleTypeRequestDTO createVehicleTypeRequestDTO)
          {
               CreateVehicleTypeRequestDTO = createVehicleTypeRequestDTO;
          }
     }
}