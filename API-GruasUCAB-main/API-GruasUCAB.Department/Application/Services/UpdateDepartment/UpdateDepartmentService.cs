namespace API_GruasUCAB.Department.Application.Services.UpdateDepartment
{
     public class UpdateDepartmentService : IService<UpdateDepartmentRequestDTO, UpdateDepartmentResponseDTO>
     {
          private readonly IDepartmentRepository _departmentRepository;
          private readonly IDepartmentFactory _departmentFactory;

          public UpdateDepartmentService(IDepartmentRepository departmentRepository, IDepartmentFactory departmentFactory)
          {
               _departmentRepository = departmentRepository;
               _departmentFactory = departmentFactory;
          }

          public async Task<UpdateDepartmentResponseDTO> Execute(UpdateDepartmentRequestDTO request)
          {
               var departmentDTO = await _departmentRepository.GetDepartmentByIdAsync(request.DepartmentId);
               if (departmentDTO == null)
               {
                    throw new DepartmentNotFoundException(request.DepartmentId);
               }

               var department = _departmentFactory.CreateDepartment(
                   new DepartmentId(departmentDTO.DepartmentId),
                   new DepartmentName(departmentDTO.Name),
                   new DepartmentDescription(departmentDTO.Descripcion)
               );

               if (!string.IsNullOrEmpty(request.Name))
               {
                    department.ChangeName(new DepartmentName(request.Name));
               }

               if (!string.IsNullOrEmpty(request.Descripcion))
               {
                    department.ChangeDescription(new DepartmentDescription(request.Descripcion));
               }

               departmentDTO.Name = department.Name.Value;
               departmentDTO.Descripcion = department.Description.Value;

               await _departmentRepository.UpdateDepartmentAsync(departmentDTO);

               return new UpdateDepartmentResponseDTO
               {
                    Success = true,
                    Message = "Department updated successfully",
                    UserEmail = request.UserEmail,
                    DepartmentId = department.Id.Id,
                    Name = department.Name.Value,
                    Descripcion = department.Description.Value
               };
          }
     }
}