namespace API_GruasUCAB.Auth.Application.Handlers.ChangePassword
{
     public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordResponseDTO>
     {
          private readonly IService<ChangePasswordRequestDTO, ChangePasswordResponseDTO> _changePasswordService;

          public ChangePasswordCommandHandler(IService<ChangePasswordRequestDTO, ChangePasswordResponseDTO> changePasswordService)
          {
               _changePasswordService = changePasswordService;
          }

          public async Task<ChangePasswordResponseDTO> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
          {
               return await _changePasswordService.Execute(request.ChangePasswordRequest);
          }
     }
}