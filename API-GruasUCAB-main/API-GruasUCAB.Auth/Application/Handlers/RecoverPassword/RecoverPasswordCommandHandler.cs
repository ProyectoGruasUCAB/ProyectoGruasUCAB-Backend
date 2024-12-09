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
               return await _recoverPasswordService.Execute(request.Request);
          }
     }
}