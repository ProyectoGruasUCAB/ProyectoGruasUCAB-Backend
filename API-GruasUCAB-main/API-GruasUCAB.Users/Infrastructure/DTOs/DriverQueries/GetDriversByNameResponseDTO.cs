namespace API_GruasUCAB.Users.Infrastructure.DTOs.DriverQueries
{
     public class GetDriversByNameResponseDTO
     {
          public List<DriverDTO> Drivers { get; set; } = new List<DriverDTO>();
     }
}