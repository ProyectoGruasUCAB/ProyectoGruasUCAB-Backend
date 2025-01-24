namespace API_GruasUCAB.Users.Application.Handlers.UpdateUser
{
     public class UpdateRecordUserDataCommandHandler : IRequestHandler<UpdateRecordUserDataCommand, UpdateRecordUserDataResponseDTO>
     {
          private readonly IService<UpdateRecordUserDataRequestDTO, UpdateRecordUserDataResponseDTO> _updateRecordUserDataService;

          public UpdateRecordUserDataCommandHandler(IService<UpdateRecordUserDataRequestDTO, UpdateRecordUserDataResponseDTO> updateRecordUserDataService)
          {
               _updateRecordUserDataService = updateRecordUserDataService;
          }

          public async Task<UpdateRecordUserDataResponseDTO> Handle(UpdateRecordUserDataCommand request, CancellationToken cancellationToken)
          {
               return await _updateRecordUserDataService.Execute(request.UpdateRecordUserDataRequestDTO);
          }
     }
}