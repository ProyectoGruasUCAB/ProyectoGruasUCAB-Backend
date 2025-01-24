namespace API_GruasUCAB.Users.Application.Queries.GetAdministratorById
{
     public class GetAdministratorByIdQuery : IRequest<GetAdministratorByIdResponseDTO>
     {
          public Guid UserId { get; set; }
          public Guid AdministratorId { get; set; }

          public GetAdministratorByIdQuery(Guid userId, Guid administratorId)
          {
               UserId = userId;
               AdministratorId = administratorId;
          }
     }
}