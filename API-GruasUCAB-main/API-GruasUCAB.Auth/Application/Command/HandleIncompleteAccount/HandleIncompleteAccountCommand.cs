using API_GruasUCAB.Auth.Infrastructure.DTOs.HandleIncompleteAccount;
using MediatR;

namespace API_GruasUCAB.Auth.Application.Command.HandleIncompleteAccount
{
     public class HandleIncompleteAccountCommand : IRequest<IncompleteAccountResponseDTO>
     {
          public IncompleteAccountRequestDTO IncompleteAccountRequest { get; set; }

          public HandleIncompleteAccountCommand(IncompleteAccountRequestDTO incompleteAccountRequest)
          {
               IncompleteAccountRequest = incompleteAccountRequest;
          }
     }
}