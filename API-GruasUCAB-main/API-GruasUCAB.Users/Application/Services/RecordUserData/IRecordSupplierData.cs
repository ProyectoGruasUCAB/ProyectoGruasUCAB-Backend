namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public interface IRecordSupplierData
     {
          Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request);
     }
}