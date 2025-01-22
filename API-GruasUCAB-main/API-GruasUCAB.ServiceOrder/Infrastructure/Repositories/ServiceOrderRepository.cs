using API_GruasUCAB.ServiceOrder.Infrastructure.Mappers;

namespace API_GruasUCAB.ServiceOrder.Infrastructure.Repositories
{
    public class ServiceOrderRepository : IServiceOrderRepository
    {
        private readonly ServiceOrderDbContext _context;

        public ServiceOrderRepository(ServiceOrderDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceOrderDTO>> GetAllServiceOrdersAsync()
        {
            return await _context.ServiceOrders
                .Select(so => new ServiceOrderDTO
                {
                    ServiceOrderId = so.Id.Value,
                    IncidentDescription = so.IncidentDescription.Value,
                    InitialLocationDriverLatitude = (float)so.InitialLocationDriver.Latitude,
                    InitialLocationDriverLongitude = (float)so.InitialLocationDriver.Longitude,
                    IncidentLocationLatitude = (float)so.IncidentLocation.Latitude,
                    IncidentLocationLongitude = (float)so.IncidentLocation.Longitude,
                    IncidentLocationEndLatitude = (float)so.IncidentLocationEnd.Latitude,
                    IncidentLocationEndLongitude = (float)so.IncidentLocationEnd.Longitude,
                    IncidentDistance = so.IncidentDistance.Value,
                    CustomerVehicleDescription = so.CustomerVehicleDescription.Value,
                    IncidentCost = so.IncidentCost.Value,
                    PolicyId = so.PolicyId.Value,
                    StatusServiceOrder = so.StatusServiceOrder.Value.ToString(),
                    IncidentDate = so.IncidentDate.Value.ToString("dd-MM-yyyy"),
                    VehicleId = so.VehicleId.Value,
                    DriverId = so.DriverId.Value,
                    CustomerId = so.CustomerId.Value,
                    OperatorId = so.OperatorId.Value,
                    ServiceFeeId = so.ServiceFeeId.Value
                })
                .ToListAsync();
        }

        public async Task<ServiceOrderDTO?> GetServiceOrderByIdAsync(Guid serviceOrderId)
        {
            var serviceOrder = await _context.ServiceOrders
                .FirstOrDefaultAsync(so => so.Id == new ServiceOrderId(serviceOrderId));

            if (serviceOrder == null)
            {
                throw new KeyNotFoundException($"ServiceOrder with ID {serviceOrderId} not found.");
            }

            return new ServiceOrderDTO
            {
                ServiceOrderId = serviceOrder.Id.Value,
                IncidentDescription = serviceOrder.IncidentDescription.Value,
                InitialLocationDriverLatitude = (float)serviceOrder.InitialLocationDriver.Latitude,
                InitialLocationDriverLongitude = (float)serviceOrder.InitialLocationDriver.Longitude,
                IncidentLocationLatitude = (float)serviceOrder.IncidentLocation.Latitude,
                IncidentLocationLongitude = (float)serviceOrder.IncidentLocation.Longitude,
                IncidentLocationEndLatitude = (float)serviceOrder.IncidentLocationEnd.Latitude,
                IncidentLocationEndLongitude = (float)serviceOrder.IncidentLocationEnd.Longitude,
                IncidentDistance = serviceOrder.IncidentDistance.Value,
                CustomerVehicleDescription = serviceOrder.CustomerVehicleDescription.Value,
                IncidentCost = serviceOrder.IncidentCost.Value,
                PolicyId = serviceOrder.PolicyId.Value,
                StatusServiceOrder = serviceOrder.StatusServiceOrder.Value.ToString(),
                IncidentDate = serviceOrder.IncidentDate.Value.ToString("dd-MM-yyyy"),
                VehicleId = serviceOrder.VehicleId.Value,
                DriverId = serviceOrder.DriverId.Value,
                CustomerId = serviceOrder.CustomerId.Value,
                OperatorId = serviceOrder.OperatorId.Value,
                ServiceFeeId = serviceOrder.ServiceFeeId.Value
            };
        }

        public async Task AddServiceOrderAsync(ServiceOrderDTO serviceOrderDto)
        {
            // Validar y ajustar la fecha del incidente
            if (!DateTime.TryParseExact(serviceOrderDto.IncidentDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                throw new ArgumentException($"Invalid incident date: {serviceOrderDto.IncidentDate}");
            }

            var serviceOrder = new Domain.AggregateRoot.ServiceOrder(
                new ServiceOrderId(serviceOrderDto.ServiceOrderId),
                new IncidentDescription(serviceOrderDto.IncidentDescription),
                new Coordinates(serviceOrderDto.InitialLocationDriverLatitude, serviceOrderDto.InitialLocationDriverLongitude),
                new Coordinates(serviceOrderDto.IncidentLocationLatitude, serviceOrderDto.IncidentLocationLongitude),
                new Coordinates(serviceOrderDto.IncidentLocationEndLatitude, serviceOrderDto.IncidentLocationEndLongitude),
                new IncidentDistance(serviceOrderDto.IncidentDistance),
                new CustomerVehicleDescription(serviceOrderDto.CustomerVehicleDescription),
                new IncidentCost(serviceOrderDto.IncidentCost),
                new PolicyId(serviceOrderDto.PolicyId),
                new StatusServiceOrder(Enum.Parse<ServiceOrderStatus>(serviceOrderDto.StatusServiceOrder)),
                new IncidentDate(parsedDate.ToString("dd-MM-yyyy")),
                new VehicleId(serviceOrderDto.VehicleId),
                new UserId(serviceOrderDto.DriverId),
                new UserId(serviceOrderDto.CustomerId),
                new UserId(serviceOrderDto.OperatorId),
                new ServiceFeeId(serviceOrderDto.ServiceFeeId)
            );

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

            // Validar y ajustar la fecha del incidente
            if (!DateTime.TryParseExact(serviceOrderDto.IncidentDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                throw new ArgumentException($"Invalid incident date: {serviceOrderDto.IncidentDate}");
            }

            serviceOrder.UpdateIncidentDescription(new IncidentDescription(serviceOrderDto.IncidentDescription));
            serviceOrder.UpdateInitialLocationDriver(new Coordinates(serviceOrderDto.InitialLocationDriverLatitude, serviceOrderDto.InitialLocationDriverLongitude));
            serviceOrder.UpdateIncidentLocation(new Coordinates(serviceOrderDto.IncidentLocationLatitude, serviceOrderDto.IncidentLocationLongitude));
            serviceOrder.UpdateIncidentLocationEnd(new Coordinates(serviceOrderDto.IncidentLocationEndLatitude, serviceOrderDto.IncidentLocationEndLongitude));
            serviceOrder.UpdateIncidentDistance(new IncidentDistance(serviceOrderDto.IncidentDistance));
            serviceOrder.UpdateCustomerVehicleDescription(new CustomerVehicleDescription(serviceOrderDto.CustomerVehicleDescription));
            serviceOrder.UpdateIncidentCost(new IncidentCost(serviceOrderDto.IncidentCost));
            serviceOrder.UpdatePolicyId(new PolicyId(serviceOrderDto.PolicyId));
            serviceOrder.UpdateStatusServiceOrder(new StatusServiceOrder(Enum.Parse<ServiceOrderStatus>(serviceOrderDto.StatusServiceOrder)));
            serviceOrder.UpdateIncidentDate(new IncidentDate(parsedDate.ToString("dd-MM-yyyy")));
            serviceOrder.UpdateVehicleId(new VehicleId(serviceOrderDto.VehicleId));
            serviceOrder.UpdateDriverId(new UserId(serviceOrderDto.DriverId));
            serviceOrder.UpdateCustomerId(new UserId(serviceOrderDto.CustomerId));
            serviceOrder.UpdateOperatorId(new UserId(serviceOrderDto.OperatorId));
            serviceOrder.UpdateServiceFeeId(new ServiceFeeId(serviceOrderDto.ServiceFeeId));

            _context.ServiceOrders.Update(serviceOrder);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ServiceOrderDTO>> GetServiceOrdersByStatusAsync(string status)
        {
            var serviceOrders = await Task.Run(() => _context.ServiceOrders
                .AsEnumerable()
                .Where(so => so.StatusServiceOrder.Value.ToString().Equals(status, StringComparison.OrdinalIgnoreCase))
                .Select(so => so.ToDTO())
                .ToList());

            return serviceOrders;
        }
    }
}