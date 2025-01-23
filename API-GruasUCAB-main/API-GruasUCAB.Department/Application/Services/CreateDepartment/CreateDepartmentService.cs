namespace API_GruasUCAB.Department.Application.Services.CreateDepartment
{
     public class CreateDepartmentService : IService<CreateDepartmentRequestDTO, CreateDepartmentResponseDTO>
     {
          private readonly IDepartmentRepository _departmentRepository;
          private readonly IDepartmentFactory _departmentFactory;
          private readonly IMapper _mapper;

          public CreateDepartmentService(IDepartmentRepository departmentRepository, IDepartmentFactory departmentFactory, IMapper mapper)
          {
               _departmentRepository = departmentRepository;
               _departmentFactory = departmentFactory;
               _mapper = mapper;
          }

          public async Task<CreateDepartmentResponseDTO> Execute(CreateDepartmentRequestDTO request)
          {
               var department = _departmentFactory.CreateDepartment(
                   new DepartmentId(Guid.NewGuid()),
                   new DepartmentName(request.Name),
                   new DepartmentDescription(request.Descripcion)
               );

               var departmentDTO = _mapper.Map<DepartmentDTO>(department);
               await _departmentRepository.AddDepartmentAsync(departmentDTO);

               return new CreateDepartmentResponseDTO
               {
                    Success = true,
                    Message = "Department created successfully",
                    UserEmail = request.UserEmail,
                    DepartmentId = department.Id.Value
               };
          }
     }
}