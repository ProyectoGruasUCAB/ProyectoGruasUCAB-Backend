namespace API_GruasUCAB.Department.Application.Services.UpdateDepartment
{
     public class UpdateDepartmentService : IService<UpdateDepartmentRequestDTO, UpdateDepartmentResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly IDepartmentFactory _departmentFactory;

          public UpdateDepartmentService(IEventStore eventStore, IDepartmentFactory departmentFactory)
          {
               _eventStore = eventStore;
               _departmentFactory = departmentFactory;
          }

          public async Task<UpdateDepartmentResponseDTO> Execute(UpdateDepartmentRequestDTO request)
          {
               var department = await _departmentFactory.GetDepartmentById(new DepartmentId(request.DepartmentId));
               if (department == null)
               {
                    throw new DepartmentNotFoundException(request.DepartmentId);
               }

               if (!string.IsNullOrEmpty(request.Name))
               {
                    department.ChangeName(new DepartmentName(request.Name));
               }

               if (!string.IsNullOrEmpty(request.Descripcion))
               {
                    department.ChangeDescription(new DepartmentDescription(request.Descripcion));
               }


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