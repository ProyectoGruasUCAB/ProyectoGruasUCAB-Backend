namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public interface IRecordUserData
     {
          Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request);
     }
}