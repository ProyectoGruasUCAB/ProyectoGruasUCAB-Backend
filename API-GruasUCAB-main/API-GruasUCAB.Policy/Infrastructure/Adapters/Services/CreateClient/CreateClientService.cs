namespace API_GruasUCAB.Policy.Infrastructure.Adapters.Services.CreateClient
{
     public class CreateClientService
     {
          private readonly PolicyDbContext _context;

          public CreateClientService(PolicyDbContext context)
          {
               _context = context;
          }

          public async Task<CreateClientResponseDTO> Execute(CreateClientRequestDTO request)
          {
               var client = new Client
               {
                    Id_cliente = request.Id_cliente == Guid.Empty ? Guid.NewGuid() : request.Id_cliente,
                    Nombre_completo_cliente = request.Nombre_completo_cliente,
                    Cedula_cliente = request.Cedula_cliente,
                    Tlf_cliente = request.Tlf_cliente,
                    Fecha_nacimiento_cliente = DateTime.SpecifyKind(request.Fecha_nacimiento_cliente, DateTimeKind.Utc)
               };

               _context.Clients.Add(client);
               await _context.SaveChangesAsync();

               return new CreateClientResponseDTO
               {
                    Id_cliente = client.Id_cliente,
                    Success = true,
                    Message = "Client created successfully."
               };
          }
     }
}