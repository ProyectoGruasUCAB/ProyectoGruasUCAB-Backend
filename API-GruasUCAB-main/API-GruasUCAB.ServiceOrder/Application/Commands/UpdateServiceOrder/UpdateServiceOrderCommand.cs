namespace API_GruasUCAB.ServiceOrder.Application.Commands.UpdateServiceOrder
{
     public class UpdateServiceOrderCommand : IRequest<UpdateServiceOrderResponseDTO>
     {
          public UpdateServiceOrderRequestDTO UpdateServiceOrderRequestDTO { get; set; }

          public UpdateServiceOrderCommand(UpdateServiceOrderRequestDTO updateServiceOrderRequestDTO)
          {
               UpdateServiceOrderRequestDTO = updateServiceOrderRequestDTO;
          }
     }
}