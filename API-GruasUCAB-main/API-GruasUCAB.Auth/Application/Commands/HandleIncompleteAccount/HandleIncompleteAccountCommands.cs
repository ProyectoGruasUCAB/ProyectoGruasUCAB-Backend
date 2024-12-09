namespace API_GruasUCAB.Auth.Application.Commands.HandleIncompleteAccount
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