namespace API_GruasUCAB.Vehicle.Application.Handlers.CreateVehicle
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, CreateVehicleResponseDTO>
    {
        private readonly IService<CreateVehicleRequestDTO, CreateVehicleResponseDTO> _createVehicleService;

        public CreateVehicleCommandHandler(IService<CreateVehicleRequestDTO, CreateVehicleResponseDTO> createVehicleService)
        {
            _createVehicleService = createVehicleService;
        }

        public async Task<CreateVehicleResponseDTO> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            return await _createVehicleService.Execute(request.CreateVehicleRequestDTO);
        }
    }
}