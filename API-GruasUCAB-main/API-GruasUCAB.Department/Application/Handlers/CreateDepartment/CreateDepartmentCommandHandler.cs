namespace API_GruasUCAB.Department.Application.Handlers.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, CreateDepartmentResponseDTO>
    {
        private readonly IService<CreateDepartmentRequestDTO, CreateDepartmentResponseDTO> _createDepartmentService;

        public CreateDepartmentCommandHandler(IService<CreateDepartmentRequestDTO, CreateDepartmentResponseDTO> createDepartmentService)
        {
            _createDepartmentService = createDepartmentService;
        }

        public async Task<CreateDepartmentResponseDTO> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _createDepartmentService.Execute(request.CreateDepartmentRequestDTO);
        }
    }
}