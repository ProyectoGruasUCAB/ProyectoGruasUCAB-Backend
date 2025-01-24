namespace API_GruasUCAB.Auth.Application.Commands.CreateUser
{
     public class CreateUserCommand : IRequest<CreateUserResponseDTO>
     {
          public CreateUserRequestDTO CreateUserRequestDTO { get; set; }

          public CreateUserCommand(CreateUserRequestDTO createUserRequestDTO)
          {
               CreateUserRequestDTO = createUserRequestDTO;
          }
     }
}