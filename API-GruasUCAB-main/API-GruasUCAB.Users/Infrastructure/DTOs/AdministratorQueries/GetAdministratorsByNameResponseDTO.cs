namespace API_GruasUCAB.Users.Infrastructure.DTOs.AdministratorQueries
{
     public class GetAdministratorsByNameResponseDTO
     {
          public List<AdministratorDTO> Administrators { get; set; } = new List<AdministratorDTO>();
     }
}