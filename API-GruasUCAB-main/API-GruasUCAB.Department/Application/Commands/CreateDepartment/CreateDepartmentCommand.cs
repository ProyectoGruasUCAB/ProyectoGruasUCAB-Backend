namespace API_GruasUCAB.Department.Application.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<CreateDepartmentResponseDTO>
    {
        public CreateDepartmentRequestDTO CreateDepartmentRequestDTO { get; set; }

        public CreateDepartmentCommand(CreateDepartmentRequestDTO createDepartmentRequestDTO)
        {
            CreateDepartmentRequestDTO = createDepartmentRequestDTO;
        }
    }
}