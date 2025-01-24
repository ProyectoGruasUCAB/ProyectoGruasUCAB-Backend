namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public interface IUpdateRecordProviderData
     {
          Task<UpdateRecordUserDataResponseDTO> Execute(UpdateRecordUserDataRequestDTO request);
     }
}