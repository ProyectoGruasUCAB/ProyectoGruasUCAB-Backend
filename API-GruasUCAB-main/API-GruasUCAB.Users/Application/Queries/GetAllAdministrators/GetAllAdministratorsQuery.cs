namespace API_GruasUCAB.Users.Application.Queries.GetAllAdministrators
{
     public class GetAllAdministratorsQuery : IRequest<GetAllAdministratorsResponseDTO>
     {
          public Guid UserId { get; set; }

          public GetAllAdministratorsQuery(Guid userId)
          {
               UserId = userId;
          }
     }
}