namespace API_GruasUCAB.Users.Infrastructure.DTOs.DriverQueries
{
     public class GetDriversBySupplierIdResponseDTO
     {
          public List<DriverDTO> Drivers { get; set; } = new List<DriverDTO>();
     }
}