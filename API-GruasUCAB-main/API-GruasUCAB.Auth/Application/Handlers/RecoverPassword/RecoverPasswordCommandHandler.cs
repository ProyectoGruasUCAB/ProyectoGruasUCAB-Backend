using API_GruasUCAB.Auth.Application.Command.RecoverPassword;
using API_GruasUCAB.Auth.Infrastructure.DTOs.RecoverPassword;
using API_GruasUCAB.Core.Application.Services;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Handlers.RecoverPassword
{
     public class RecoverPasswordCommandHandler : IRequestHandler<RecoverPasswordCommand, RecoverPasswordResponseDTO>
     {
          private readonly IService<RecoverPasswordRequestDTO, RecoverPasswordResponseDTO> _recoverPasswordService;

          public RecoverPasswordCommandHandler(IService<RecoverPasswordRequestDTO, RecoverPasswordResponseDTO> recoverPasswordService)
          {
               _recoverPasswordService = recoverPasswordService;
          }

          public async Task<RecoverPasswordResponseDTO> Handle(RecoverPasswordCommand request, CancellationToken cancellationToken)
          {
               var response = await _recoverPasswordService.Execute(request.Request);
               return response;
          }
     }
}