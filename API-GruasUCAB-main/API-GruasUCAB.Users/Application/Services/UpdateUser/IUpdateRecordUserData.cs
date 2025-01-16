namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public interface IUpdateRecordUserData
     {
          Task<UpdateRecordUserDataResponseDTO> Execute(UpdateRecordUserDataRequestDTO request);
     }
}