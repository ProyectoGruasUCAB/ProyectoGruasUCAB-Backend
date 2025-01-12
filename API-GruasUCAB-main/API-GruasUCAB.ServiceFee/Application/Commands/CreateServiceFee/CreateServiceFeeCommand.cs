namespace API_GruasUCAB.ServiceFee.Application.Commands.CreateServiceFee
{
     public class CreateServiceFeeCommand : IRequest<CreateServiceFeeResponseDTO>
     {
          public CreateServiceFeeRequestDTO CreateServiceFeeRequestDTO { get; set; }

          public CreateServiceFeeCommand(CreateServiceFeeRequestDTO createServiceFeeRequestDTO)
          {
               CreateServiceFeeRequestDTO = createServiceFeeRequestDTO;
          }
     }
}