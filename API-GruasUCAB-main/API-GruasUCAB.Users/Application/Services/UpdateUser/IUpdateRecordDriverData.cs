namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public interface IUpdateRecordDriverData
     {
          Task<UpdateRecordUserDataResponseDTO> Execute(UpdateRecordUserDataRequestDTO request);
     }
}