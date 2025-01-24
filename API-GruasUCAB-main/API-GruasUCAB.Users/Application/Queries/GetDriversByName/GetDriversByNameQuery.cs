namespace API_GruasUCAB.Users.Application.Queries.GetDriversByName
{
     public class GetDriversByNameQuery : IRequest<GetDriversByNameResponseDTO>
     {
          public Guid UserId { get; set; }
          public string Name { get; set; }

          public GetDriversByNameQuery(Guid userId, string name)
          {
               UserId = userId;
               Name = name;
          }
     }
}