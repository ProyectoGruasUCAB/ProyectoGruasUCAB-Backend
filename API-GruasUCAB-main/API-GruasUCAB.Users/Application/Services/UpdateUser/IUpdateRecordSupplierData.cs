namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public interface IUpdateRecordSupplierData
     {
          Task<UpdateRecordUserDataResponseDTO> Execute(UpdateRecordUserDataRequestDTO request);
     }
}