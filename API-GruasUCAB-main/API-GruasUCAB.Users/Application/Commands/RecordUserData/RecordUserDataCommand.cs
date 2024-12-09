namespace API_GruasUCAB.Users.Application.Commands.RecordUserData
{
     public class RecordUserDataCommand : IRequest<RecordUserDataResponseDTO>
     {
          public RecordUserDataRequestDTO RecordUserDataRequestDTO { get; set; }

          public RecordUserDataCommand(RecordUserDataRequestDTO recordUserDataRequestDTO)
          {
               RecordUserDataRequestDTO = recordUserDataRequestDTO;
          }
     }
}