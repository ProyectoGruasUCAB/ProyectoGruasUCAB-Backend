namespace API_GruasUCAB.Users.Application.Commands.UpdateUser
{
     public class UpdateRecordUserDataCommand : IRequest<UpdateRecordUserDataResponseDTO>
     {
          public UpdateRecordUserDataRequestDTO UpdateRecordUserDataRequestDTO { get; set; }

          public UpdateRecordUserDataCommand(UpdateRecordUserDataRequestDTO updateRecordUserDataRequestDTO)
          {
               UpdateRecordUserDataRequestDTO = updateRecordUserDataRequestDTO;
          }
     }
}