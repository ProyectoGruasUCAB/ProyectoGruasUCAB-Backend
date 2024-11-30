using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Command.CreateUser
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