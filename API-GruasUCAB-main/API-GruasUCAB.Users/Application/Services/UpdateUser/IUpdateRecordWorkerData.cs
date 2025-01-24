namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public interface IUpdateRecordWorkerData
     {
          Task<UpdateRecordUserDataResponseDTO> Execute(UpdateRecordUserDataRequestDTO request);
     }
}