using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using API_GruasUCAB.Core.Application.Services;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Command.HandleIncompleteAccount
{
     public class HandleIncompleteAccountCommandHandler : IRequestHandler<HandleIncompleteAccountCommand, IncompleteAccountResponseDTO>
     {
          private readonly IService<IncompleteAccountRequestDTO, IncompleteAccountResponseDTO> _handleIncompleteAccountService;

          public HandleIncompleteAccountCommandHandler(IService<IncompleteAccountRequestDTO, IncompleteAccountResponseDTO> handleIncompleteAccountService)
          {
               _handleIncompleteAccountService = handleIncompleteAccountService;
          }

          public async Task<IncompleteAccountResponseDTO> Handle(HandleIncompleteAccountCommand request, CancellationToken cancellationToken)
          {
               return await _handleIncompleteAccountService.Execute(request.IncompleteAccountRequest);
          }
     }
}