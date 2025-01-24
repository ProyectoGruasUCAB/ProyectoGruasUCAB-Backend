namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public interface IRecordWorkerData
     {
          Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request);
     }
}