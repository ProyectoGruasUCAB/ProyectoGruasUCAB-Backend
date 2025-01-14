namespace API_GruasUCAB.Users.Infrastructure.DTOs.AdministratorQueries
{
     public class GetAllAdministratorsResponseDTO
     {
          public List<AdministratorDTO> Administrators { get; set; } = new List<AdministratorDTO>();
     }
}