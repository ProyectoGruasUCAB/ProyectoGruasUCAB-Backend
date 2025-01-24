namespace API_GruasUCAB.Policy.Infrastructure.Repositories
{
     public class ClientRepository : IClientRepository
     {
          private readonly PolicyDbContext _context;

          public ClientRepository(PolicyDbContext context)
          {
               _context = context;
          }

          public async Task<List<ClientDTO>> GetAllClientsAsync()
          {
               return await _context.Clients
                   .Select(c => new ClientDTO
                   {
                        Id_cliente = c.Id_cliente,
                        Nombre_completo_cliente = c.Nombre_completo_cliente,
                        Cedula_cliente = c.Cedula_cliente,
                        Tlf_cliente = c.Tlf_cliente,
                        Fecha_nacimiento_cliente = c.Fecha_nacimiento_cliente
                   })
                   .ToListAsync();
          }

          public async Task<ClientDTO> GetClientByIdAsync(Guid clientId)
          {
               var client = await _context.Clients.FindAsync(clientId);
               if (client == null)
               {
                    throw new KeyNotFoundException($"Client with ID {clientId} not found.");
               }

               return new ClientDTO
               {
                    Id_cliente = client.Id_cliente,
                    Nombre_completo_cliente = client.Nombre_completo_cliente,
                    Cedula_cliente = client.Cedula_cliente,
                    Tlf_cliente = client.Tlf_cliente,
                    Fecha_nacimiento_cliente = client.Fecha_nacimiento_cliente
               };
          }

          public async Task<ClientDTO> GetClientByClientNumberAsync(string clientNumber)
          {
               var client = await _context.Clients
                   .FirstOrDefaultAsync(c => c.Cedula_cliente == int.Parse(clientNumber));
               if (client == null)
               {
                    throw new KeyNotFoundException($"Client with number {clientNumber} not found.");
               }

               return new ClientDTO
               {
                    Id_cliente = client.Id_cliente,
                    Nombre_completo_cliente = client.Nombre_completo_cliente,
                    Cedula_cliente = client.Cedula_cliente,
                    Tlf_cliente = client.Tlf_cliente,
                    Fecha_nacimiento_cliente = client.Fecha_nacimiento_cliente
               };
          }

          public async Task AddClientAsync(ClientDTO clientDto)
          {
               var client = new Client
               {
                    Id_cliente = clientDto.Id_cliente,
                    Nombre_completo_cliente = clientDto.Nombre_completo_cliente,
                    Cedula_cliente = clientDto.Cedula_cliente,
                    Tlf_cliente = clientDto.Tlf_cliente,
                    Fecha_nacimiento_cliente = clientDto.Fecha_nacimiento_cliente
               };

               _context.Clients.Add(client);
               await _context.SaveChangesAsync();
          }
     }
}