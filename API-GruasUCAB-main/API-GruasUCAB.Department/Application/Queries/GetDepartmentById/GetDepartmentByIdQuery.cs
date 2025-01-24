namespace API_GruasUCAB.Department.Application.Queries.GetDepartmentById
{
     public class GetDepartmentByIdQuery : IRequest<GetDepartmentByIdResponseDTO>
     {
          public Guid UserId { get; set; }
          public Guid DepartmentId { get; set; }

          public GetDepartmentByIdQuery(Guid userId, Guid departmentId)
          {
               UserId = userId;
               DepartmentId = departmentId;
          }
     }
}