namespace API_GruasUCAB.ServiceOrder.Infrastructure.Repositories
{
    public class ServiceOrderRepository : IServiceOrderRepository
    {
        private readonly List<ServiceOrderDTO> _serviceOrders = new List<ServiceOrderDTO>
{

     new ServiceOrderDTO
            {
                ServiceOrderId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                StatusServiceOrder = "PorAsignar",
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
                PolicyId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                IncidentDate = "17-10-2025",
                VehicleId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                DriverId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                CustomerId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                OperatorId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ServiceFeeId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
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
                PolicyId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                StatusServiceOrder = "PorAceptado",
                IncidentDate = "17-10-2015",
                VehicleId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                DriverId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                CustomerId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                OperatorId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                ServiceFeeId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
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
                PolicyId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                StatusServiceOrder = "Aceptado",
                IncidentDate = "17-10-2025",
                VehicleId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                DriverId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                CustomerId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                OperatorId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                ServiceFeeId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            },
            new ServiceOrderDTO
            {
                ServiceOrderId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                IncidentDescription = "Problema de batería en la ciudad",
                InitialLocationDriverLat = 10.8000,
                InitialLocationDriverLon = -66.9167,
                IncidentLocationLat = 10.8010,
                IncidentLocationLon = -66.9177,
                IncidentLocationEndLat = 10.8020,
                IncidentLocationEndLon = -66.9187,
                IncidentDistance = 1.0f,
                CustomerVehicleDescription = "Honda Civic 2019",
                IncidentCost = 180.0f,
                PolicyId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                StatusServiceOrder = "Localizado",
                IncidentDate = "17-10-2025",
                VehicleId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                DriverId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                CustomerId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                OperatorId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                ServiceFeeId = Guid.Parse("44444444-4444-4444-4444-444444444444")
            },
            new ServiceOrderDTO
            {
                ServiceOrderId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                IncidentDescription = "Problema de motor en la autopista",
                InitialLocationDriverLat = 10.9000,
                InitialLocationDriverLon = -66.9167,
                IncidentLocationLat = 10.9010,
                IncidentLocationLon = -66.9177,
                IncidentLocationEndLat = 10.9020,
                IncidentLocationEndLon = -66.9187,
                IncidentDistance = 2.5f,
                CustomerVehicleDescription = "Mazda 3 2020",
                IncidentCost = 220.0f,
                PolicyId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                StatusServiceOrder = "EnProceso",
                IncidentDate = "17-10-2025",
                VehicleId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                DriverId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                CustomerId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                OperatorId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                ServiceFeeId = Guid.Parse("55555555-5555-5555-5555-555555555555")
            },
            new ServiceOrderDTO
            {
                ServiceOrderId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                IncidentDescription = "Problema de frenos en la avenida",
                InitialLocationDriverLat = 11.0000,
                InitialLocationDriverLon = -66.9167,
                IncidentLocationLat = 11.0010,
                IncidentLocationLon = -66.9177,
                IncidentLocationEndLat = 11.0020,
                IncidentLocationEndLon = -66.9187,
                IncidentDistance = 3.5f,
                CustomerVehicleDescription = "Nissan Sentra 2021",
                IncidentCost = 300.0f,
                PolicyId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                StatusServiceOrder = "Finalizado",
                IncidentDate = "17-10-2025",
                VehicleId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                DriverId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                CustomerId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                OperatorId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                ServiceFeeId = Guid.Parse("66666666-6666-6666-6666-666666666666")
            },
            new ServiceOrderDTO
            {
                ServiceOrderId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                IncidentDescription = "Problema de transmisión en el centro",
                InitialLocationDriverLat = 11.1000,
                InitialLocationDriverLon = -66.9167,
                IncidentLocationLat = 11.1010,
                IncidentLocationLon = -66.9177,
                IncidentLocationEndLat = 11.1020,
                IncidentLocationEndLon = -66.9187,
                IncidentDistance = 4.0f,
                CustomerVehicleDescription = "Hyundai Elantra 2022",
                IncidentCost = 350.0f,
                PolicyId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                StatusServiceOrder = "Cancelado",
                IncidentDate = "17-10-2025",
                VehicleId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                DriverId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                CustomerId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                OperatorId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                ServiceFeeId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
            },
            new ServiceOrderDTO
            {
                ServiceOrderId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                IncidentDescription = "Problema de suspensión en la autopista",
                InitialLocationDriverLat = 11.2000,
                InitialLocationDriverLon = -66.9167,
                IncidentLocationLat = 11.2010,
                IncidentLocationLon = -66.9177,
                IncidentLocationEndLat = 11.2020,
                IncidentLocationEndLon = -66.9187,
                IncidentDistance = 4.5f,
                CustomerVehicleDescription = "Kia Rio 2023",
                IncidentCost = 400.0f,
                PolicyId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                StatusServiceOrder = "CanceladoPorCobrar",
                IncidentDate = "17-10-2025",
                VehicleId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                DriverId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                CustomerId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                OperatorId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                ServiceFeeId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
            },
            new ServiceOrderDTO
            {
                ServiceOrderId = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                IncidentDescription = "Problema de dirección en la ciudad",
                InitialLocationDriverLat = 11.3000,
                InitialLocationDriverLon = -66.9167,
                IncidentLocationLat = 11.3010,
                IncidentLocationLon = -66.9177,
                IncidentLocationEndLat = 11.3020,
                IncidentLocationEndLon = -66.9187,
                IncidentDistance = 5.0f,
                CustomerVehicleDescription = "Volkswagen Jetta 2024",
                IncidentCost = 450.0f,
                PolicyId = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                StatusServiceOrder = "Pagado",
                IncidentDate = "17-10-2025",
                VehicleId = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                DriverId = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                CustomerId = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                OperatorId = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                ServiceFeeId = Guid.Parse("99999999-9999-9999-9999-999999999999"),
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