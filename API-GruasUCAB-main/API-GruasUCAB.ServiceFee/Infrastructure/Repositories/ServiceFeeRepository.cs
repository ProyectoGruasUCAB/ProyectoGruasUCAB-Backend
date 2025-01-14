namespace API_GruasUCAB.ServiceFee.Infrastructure.Repositories
{
     public class ServiceFeeRepository : IServiceFeeRepository
     {
          private readonly List<ServiceFeeDTO> _serviceFees;

          public ServiceFeeRepository()
          {
               // Inicializar la lista con datos de ejemplo
               _serviceFees = new List<ServiceFeeDTO>
            {
                new ServiceFeeDTO
                {
                    ServiceFeeId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Basic Service",
                    Price = 50.0f,
                    PriceKm = 5.0f,
                    Radius = 10
                },
                new ServiceFeeDTO
                {
                    ServiceFeeId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Premium Service",
                    Price = 100.0f,
                    PriceKm = 10.0f,
                    Radius = 20
                },
                new ServiceFeeDTO
                {
                    ServiceFeeId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "VIP Service",
                    Price = 200.0f,
                    PriceKm = 20.0f,
                    Radius = 30
                }
            };
          }

          public async Task<List<ServiceFeeDTO>> GetAllServiceFeesAsync()
          {
               // Simulación de una llamada a la base de datos
               return await Task.FromResult(_serviceFees);
          }

          public async Task<ServiceFeeDTO> GetServiceFeeByIdAsync(Guid id)
          {
               // Simulación de una llamada a la base de datos
               var serviceFee = _serviceFees.FirstOrDefault(s => s.ServiceFeeId == id);
               if (serviceFee == null)
               {
                    throw new KeyNotFoundException($"Service fee with ID {id} not found.");
               }
               return await Task.FromResult(serviceFee);
          }

          public async Task<ServiceFeeDTO> GetServiceFeeByNameAsync(string name)
          {
               // Simulación de una llamada a la base de datos
               var serviceFee = _serviceFees.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
               if (serviceFee == null)
               {
                    throw new KeyNotFoundException($"Service fee with name {name} not found.");
               }
               return await Task.FromResult(serviceFee);
          }
     }
}