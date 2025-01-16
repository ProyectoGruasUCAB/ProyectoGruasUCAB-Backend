namespace API_GruasUCAB.Department.Application.Services.CreateDepartment
{
     public class CreateDepartmentService : IService<CreateDepartmentRequestDTO, CreateDepartmentResponseDTO>
     {
          private readonly IDepartmentRepository _departmentRepository;
          private readonly IDepartmentFactory _departmentFactory;

          public CreateDepartmentService(IDepartmentRepository departmentRepository, IDepartmentFactory departmentFactory)
          {
               _departmentRepository = departmentRepository;
               _departmentFactory = departmentFactory;
          }

          public async Task<CreateDepartmentResponseDTO> Execute(CreateDepartmentRequestDTO request)
          {
               var department = _departmentFactory.CreateDepartment(
                   new DepartmentId(Guid.NewGuid()),
                   new DepartmentName(request.Name),
                   new DepartmentDescription(request.Descripcion)
               );

               var departmentDTO = new DepartmentDTO
               {
                    DepartmentId = department.Id.Id,
                    Name = department.Name.Value,
                    Descripcion = department.Description.Value
               };

               await _departmentRepository.AddDepartmentAsync(departmentDTO);

               return new CreateDepartmentResponseDTO
               {
                    Success = true,
                    Message = "Department created successfully",
                    UserEmail = request.UserEmail,
                    DepartmentId = department.Id.Id
               };
          }
     }
}