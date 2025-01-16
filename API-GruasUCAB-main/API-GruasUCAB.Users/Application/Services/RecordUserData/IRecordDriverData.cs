namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public interface IRecordDriverData
     {
          Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request);
     }
}