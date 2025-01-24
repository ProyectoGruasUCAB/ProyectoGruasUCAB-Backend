namespace API_GruasUCAB.Vehicle.Application.Commands.CreateVehicle
{
    public class CreateVehicleCommand : IRequest<CreateVehicleResponseDTO>
    {
        public CreateVehicleRequestDTO CreateVehicleRequestDTO { get; set; }

        public CreateVehicleCommand(CreateVehicleRequestDTO createVehicleRequestDTO)
        {
            CreateVehicleRequestDTO = createVehicleRequestDTO;
        }
    }
}