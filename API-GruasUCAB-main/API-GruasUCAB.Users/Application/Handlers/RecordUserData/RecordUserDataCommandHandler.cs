namespace API_GruasUCAB.Users.Application.Handlers.RecordUserData
{
     public class RecordUserDataCommandHandler : IRequestHandler<RecordUserDataCommand, RecordUserDataResponseDTO>
     {
          private readonly IService<RecordUserDataRequestDTO, RecordUserDataResponseDTO> _recordUserDataService;

          public RecordUserDataCommandHandler(IService<RecordUserDataRequestDTO, RecordUserDataResponseDTO> recordUserDataService)
          {
               _recordUserDataService = recordUserDataService;
          }

          public async Task<RecordUserDataResponseDTO> Handle(RecordUserDataCommand request, CancellationToken cancellationToken)
          {
               return await _recordUserDataService.Execute(request.RecordUserDataRequestDTO);
          }
     }
}