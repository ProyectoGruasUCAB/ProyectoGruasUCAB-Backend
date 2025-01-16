namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public interface IRecordAdministratorData
     {
          Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request);
     }
}