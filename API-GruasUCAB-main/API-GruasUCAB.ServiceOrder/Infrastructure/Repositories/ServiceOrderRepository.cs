namespace API_GruasUCAB.ServiceOrder.Infrastructure.Repositories
{
    public class ServiceOrderRepository : IServiceOrderRepository
    {
        private readonly ServiceOrderDbContext _context;
        private readonly UserDbContext _userContext;

        public ServiceOrderRepository(ServiceOrderDbContext context, UserDbContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        public async Task<List<ServiceOrderDTO>> GetAllServiceOrdersAsync()
        {
            var serviceOrders = await _context.ServiceOrders.ToListAsync();
            return serviceOrders.Select(so => so.ToDTO()).ToList();
        }

        public async Task<ServiceOrderDTO?> GetServiceOrderByIdAsync(Guid serviceOrderId)
        {
            var serviceOrder = await _context.ServiceOrders
                .FirstOrDefaultAsync(so => so.Id == new ServiceOrderId(serviceOrderId));

            if (serviceOrder == null)
            {
                throw new KeyNotFoundException($"ServiceOrder with ID {serviceOrderId} not found.");
            }

            return serviceOrder.ToDTO();
        }

        public async Task<List<ServiceOrderDTO>> GetServiceOrdersByStatusAsync(string status)
        {
            var serviceOrders = await Task.Run(() => _context.ServiceOrders
                .AsEnumerable()
                .Where(so => so.StatusServiceOrder.Value.ToString().Equals(status, StringComparison.OrdinalIgnoreCase))
                .ToList());

            return serviceOrders.Select(so => so.ToDTO()).ToList();
        }

        public async Task<List<ServiceOrderDTO>> GetServiceOrdersByDriverIdAsync(Guid driverId)
        {
            var serviceOrders = await _context.ServiceOrders
                .Where(so => so.DriverId == new UserId(driverId))
                .ToListAsync();

            return serviceOrders.Select(so => so.ToDTO()).ToList();
        }

        public async Task<List<ServiceOrderDTO>> GetServiceOrdersByVehicleIdAsync(Guid vehicleId)
        {
            var serviceOrders = await _context.ServiceOrders
                .Where(so => so.VehicleId == new VehicleId(vehicleId))
                .ToListAsync();

            return serviceOrders.Select(so => so.ToDTO()).ToList();
        }

        public async Task<List<ServiceOrderDTO>> GetServiceOrdersByOperatorIdAsync(Guid operatorId)
        {
            var serviceOrders = await _context.ServiceOrders
                .Where(so => so.OperatorId == new UserId(operatorId))
                .ToListAsync();

            return serviceOrders.Select(so => so.ToDTO()).ToList();
        }

        public async Task<List<ServiceOrderDTO>> GetServiceOrdersByClientIdAsync(Guid clientId)
        {
            var serviceOrders = await _context.ServiceOrders
                .Where(so => so.CustomerId == new UserId(clientId))
                .ToListAsync();

            return serviceOrders.Select(so => so.ToDTO()).ToList();
        }

        public async Task<List<ServiceOrderDTO>> GetServiceOrdersBySupplierIdAsync(Guid supplierId)
        {
            var serviceOrders = await _context.ServiceOrders.ToListAsync();
            var drivers = await _userContext.Drivers.ToListAsync();

            var filteredServiceOrders = serviceOrders
                .Join(drivers,
                      so => so.DriverId,
                      d => d.Id,
                      (so, d) => new { ServiceOrder = so, Driver = d })
                .Where(joined => joined.Driver.SupplierId.Value == supplierId)
                .Select(joined => joined.ServiceOrder)
                .ToList();

            return filteredServiceOrders.Select(so => so.ToDTO()).ToList();
        }

        public async Task AddServiceOrderAsync(ServiceOrderDTO serviceOrderDto)
        {
            if (!DateTime.TryParseExact(serviceOrderDto.IncidentDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                throw new ArgumentException($"Invalid incident date: {serviceOrderDto.IncidentDate}");
            }

            var serviceOrder = serviceOrderDto.ToEntity();
            serviceOrder.UpdateIncidentDate(new IncidentDate(parsedDate.ToString("dd-MM-yyyy")));

            _context.ServiceOrders.Add(serviceOrder);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceOrderAsync(ServiceOrderDTO serviceOrderDto)
        {
            var serviceOrder = await _context.ServiceOrders
                .FirstOrDefaultAsync(so => so.Id == new ServiceOrderId(serviceOrderDto.ServiceOrderId));

            if (serviceOrder == null)
            {
                throw new KeyNotFoundException($"ServiceOrder with ID {serviceOrderDto.ServiceOrderId} not found.");
            }

            if (!DateTime.TryParseExact(serviceOrderDto.IncidentDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                throw new ArgumentException($"Invalid incident date: {serviceOrderDto.IncidentDate}");
            }

            serviceOrderDto.ToEntity();
            serviceOrder.UpdateIncidentDate(new IncidentDate(parsedDate.ToString("dd-MM-yyyy")));

            _context.ServiceOrders.Update(serviceOrder);
            await _context.SaveChangesAsync();
        }
    }
}