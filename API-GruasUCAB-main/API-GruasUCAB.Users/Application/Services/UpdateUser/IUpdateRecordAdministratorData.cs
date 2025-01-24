namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public interface IUpdateRecordAdministratorData
     {
          Task<UpdateRecordUserDataResponseDTO> Execute(UpdateRecordUserDataRequestDTO request);
     }
}