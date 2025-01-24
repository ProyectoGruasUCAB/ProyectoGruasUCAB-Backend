namespace API_GruasUCAB.ServiceOrder.Application.Commands.CreateServiceOrder
{
     public class CreateServiceOrderCommand : IRequest<CreateServiceOrderResponseDTO>
     {
          public CreateServiceOrderRequestDTO CreateServiceOrderRequestDTO { get; set; }

          public CreateServiceOrderCommand(CreateServiceOrderRequestDTO createServiceOrderRequestDTO)
          {
               CreateServiceOrderRequestDTO = createServiceOrderRequestDTO;
          }
     }
}