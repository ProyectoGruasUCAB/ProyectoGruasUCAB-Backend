using API_GruasUCAB.Auth.Application.Command.CreateUser;
using API_GruasUCAB.Auth.Infrastructure.DTOs.CreateUser;
using API_GruasUCAB.Core.Application.Services;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Handlers.CreateUser
{
     public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponseDTO>
     {
          private readonly IService<CreateUserRequestDTO, CreateUserResponseDTO> _createUserService;

          public CreateUserCommandHandler(IService<CreateUserRequestDTO, CreateUserResponseDTO> createUserService)
          {
               _createUserService = createUserService;
          }

          public async Task<CreateUserResponseDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
          {
               return await _createUserService.Execute(request.CreateUserRequestDTO);
          }
     }
}