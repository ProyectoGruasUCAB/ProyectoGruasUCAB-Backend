namespace API_GruasUCAB.Department.Application.Queries.GetAllDepartments
{
     public class GetAllDepartmentsQuery : IRequest<GetAllDepartmentsResponseDTO>
     {
          public Guid UserId { get; set; }

          public GetAllDepartmentsQuery(Guid userId)
          {
               UserId = userId;
          }
     }
}