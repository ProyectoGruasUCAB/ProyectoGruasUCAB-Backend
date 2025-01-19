namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public interface IRecordProviderData
     {
          Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request);
     }
}