namespace API_GruasUCAB.Users.Domain.Repositories
{
     public interface IAdministratorRepository
     {
          Task<List<AdministratorDTO>> GetAllAdministratorsAsync();
          Task<AdministratorDTO> GetAdministratorByIdAsync(Guid id);
          Task<List<AdministratorDTO>> GetAdministratorsByNameAsync(string name);
     }
}