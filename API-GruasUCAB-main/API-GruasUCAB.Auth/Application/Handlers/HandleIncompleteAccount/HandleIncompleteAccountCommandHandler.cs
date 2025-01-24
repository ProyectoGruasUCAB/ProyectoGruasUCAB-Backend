namespace API_GruasUCAB.Auth.Application.Handlers.HandleIncompleteAccount
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