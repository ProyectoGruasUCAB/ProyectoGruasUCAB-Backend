namespace API_GruasUCAB.Users.Application.Queries.GetAdministratorsByName
{
     public class GetAdministratorsByNameQuery : IRequest<GetAdministratorsByNameResponseDTO>
     {
          public Guid UserId { get; set; }
          public string Name { get; set; }

          public GetAdministratorsByNameQuery(Guid userId, string name)
          {
               UserId = userId;
               Name = name;
          }
     }
}