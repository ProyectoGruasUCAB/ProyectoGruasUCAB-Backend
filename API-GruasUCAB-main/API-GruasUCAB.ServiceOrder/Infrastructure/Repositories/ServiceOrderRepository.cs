namespace API_GruasUCAB.ServiceOrder.Infrastructure.Repositories
{
     public class ServiceOrderRepository : IServiceOrderRepository
     {
          private readonly List<ServiceOrderDTO> _serviceOrders = new List<ServiceOrderDTO>
{
    new ServiceOrderDTO
    {
        ServiceOrderId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        IncidentDescription = "Accidente en la autopista",
        InitialLocationDriverLat = 10.5000,
        InitialLocationDriverLon = -66.9167,
        IncidentLocationLat = 10.5010,
        IncidentLocationLon = -66.9177,
        IncidentLocationEndLat = 10.5020,
        IncidentLocationEndLon = -66.9187,
        IncidentDistance = 1.5f,
        CustomerVehicleDescription = "Toyota Corolla 2015",
        IncidentCost = 150.0f,
        PolicyId = Guid.NewGuid(),
        StatusServiceOrder = "PorAceptado",
        IncidentDate = "17-10-2025",
        VehicleId = Guid.NewGuid(),
        DriverId = Guid.NewGuid(),
        CustomerId = Guid.NewGuid(),
        OperatorId = Guid.NewGuid(),
        ServiceFeeId = Guid.NewGuid()
    },
    new ServiceOrderDTO
    {
        ServiceOrderId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        IncidentDescription = "Falla mecánica en la avenida",
        InitialLocationDriverLat = 10.6000,
        InitialLocationDriverLon = -66.9167,
        IncidentLocationLat = 10.6010,
        IncidentLocationLon = -66.9177,
        IncidentLocationEndLat = 10.6020,
        IncidentLocationEndLon = -66.9187,
        IncidentDistance = 2.0f,
        CustomerVehicleDescription = "Ford Fiesta 2018",
        IncidentCost = 200.0f,
        PolicyId = Guid.NewGuid(),
        StatusServiceOrder = "Aceptado",
        IncidentDate = "17-10-2015",
        VehicleId = Guid.NewGuid(),
        DriverId = Guid.NewGuid(),
        CustomerId = Guid.NewGuid(),
        OperatorId = Guid.NewGuid(),
        ServiceFeeId = Guid.NewGuid()
    },
    new ServiceOrderDTO
    {
        ServiceOrderId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
        IncidentDescription = "Problema eléctrico en el centro",
        InitialLocationDriverLat = 10.7000,
        InitialLocationDriverLon = -66.9167,
        IncidentLocationLat = 10.7010,
        IncidentLocationLon = -66.9177,
        IncidentLocationEndLat = 10.7020,
        IncidentLocationEndLon = -66.9187,
        IncidentDistance = 3.0f,
        CustomerVehicleDescription = "Chevrolet Aveo 2017",
        IncidentCost = 250.0f,
        PolicyId = Guid.NewGuid(),
        StatusServiceOrder = "Aceptado",
        IncidentDate = "17-10-2025",
        VehicleId = Guid.NewGuid(),
        DriverId = Guid.NewGuid(),
        CustomerId = Guid.NewGuid(),
        OperatorId = Guid.NewGuid(),
        ServiceFeeId = Guid.NewGuid()
    }
};

          public async Task<List<ServiceOrderDTO>> GetAllServiceOrdersAsync()
          {
               // Simulación de acceso a datos asíncrono
               return await Task.FromResult(_serviceOrders);
          }

          public async Task<ServiceOrderDTO?> GetServiceOrderByIdAsync(Guid serviceOrderId)
          {
               // Simulación de acceso a datos asíncrono
               var serviceOrder = _serviceOrders.FirstOrDefault(so => so.ServiceOrderId == serviceOrderId);
               return await Task.FromResult(serviceOrder);
          }

          public async Task AddServiceOrderAsync(ServiceOrderDTO serviceOrder)
          {
               // Simulación de acceso a datos asíncrono
               _serviceOrders.Add(serviceOrder);
               await Task.CompletedTask;
          }

          public async Task UpdateServiceOrderAsync(ServiceOrderDTO serviceOrder)
          {
               // Simulación de acceso a datos asíncrono
               var existingServiceOrder = _serviceOrders.FirstOrDefault(so => so.ServiceOrderId == serviceOrder.ServiceOrderId);
               if (existingServiceOrder != null)
               {
                    _serviceOrders.Remove(existingServiceOrder);
                    _serviceOrders.Add(serviceOrder);
               }
               await Task.CompletedTask;
          }

          public async Task<List<ServiceOrderDTO>> GetServiceOrdersByStatusAsync(string status)
          {
               // Simulación de acceso a datos asíncrono
               var serviceOrders = _serviceOrders.Where(so => so.StatusServiceOrder == status).ToList();
               return await Task.FromResult(serviceOrders);
          }
     }
}