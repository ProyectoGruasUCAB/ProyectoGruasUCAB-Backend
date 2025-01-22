namespace API_GruasUCAB.Policy.Infrastructure.Adapters.Repositories
{
     public interface IClientRepository
     {
          Task<List<ClientDTO>> GetAllClientsAsync();
          Task<ClientDTO> GetClientByIdAsync(Guid clientId);
          Task<ClientDTO> GetClientByClientNumberAsync(string clientNumber);
          Task AddClientAsync(ClientDTO clientDto);
     }
}