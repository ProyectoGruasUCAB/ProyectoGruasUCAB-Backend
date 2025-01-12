namespace API_GruasUCAB.ServiceFee.Application.Commands.UpdateServiceFee
{
     public class UpdateServiceFeeCommand : IRequest<UpdateServiceFeeResponseDTO>
     {
          public UpdateServiceFeeRequestDTO UpdateServiceFeeRequestDTO { get; set; }

          public UpdateServiceFeeCommand(UpdateServiceFeeRequestDTO updateServiceFeeRequestDTO)
          {
               UpdateServiceFeeRequestDTO = updateServiceFeeRequestDTO;
          }
     }
}