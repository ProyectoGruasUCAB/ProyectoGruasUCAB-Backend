namespace API_GruasUCAB.Department.Application.Queries.GetDepartmentByName
{
     public class GetDepartmentByNameQuery : IRequest<GetDepartmentByNameResponseDTO>
     {
          public Guid UserId { get; set; }
          public string Name { get; set; }

          public GetDepartmentByNameQuery(Guid userId, string name)
          {
               UserId = userId;
               Name = name;
          }
     }
}