namespace API_GruasUCAB.ServiceFee.Infrastructure.DTOs.ServiceFeeQueries
{
     public class GetAllServiceFeesResponseDTO
     {
          public List<ServiceFeeDTO> ServiceFees { get; set; } = new List<ServiceFeeDTO>();
     }
}