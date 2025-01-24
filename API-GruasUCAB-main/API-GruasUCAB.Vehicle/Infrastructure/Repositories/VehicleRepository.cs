namespace API_GruasUCAB.Vehicle.Infrastructure.Repositories
{
     public class VehicleRepository : IVehicleRepository
     {
          private readonly VehicleDbContext _context;
          private readonly IMapper _mapper;

          public VehicleRepository(VehicleDbContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }

          public async Task<List<VehicleDTO>> GetAllVehiclesAsync()
          {
               var vehicles = await _context.Vehicles.ToListAsync();
               return _mapper.Map<List<VehicleDTO>>(vehicles);
          }

          public async Task<VehicleDTO> GetVehicleByIdAsync(Guid id)
          {
               var vehicle = await _context.Vehicles
                   .FirstOrDefaultAsync(v => v.Id == new VehicleId(id));

               if (vehicle == null)
               {
                    throw new KeyNotFoundException($"Vehicle with ID {id} not found.");
               }

               return _mapper.Map<VehicleDTO>(vehicle);
          }

          public async Task<VehicleDTO> GetVehicleByLicensePlateAsync(string licensePlate)
          {
               var vehicles = await _context.Vehicles.ToListAsync();

               var vehicle = vehicles
                   .AsEnumerable()
                   .FirstOrDefault(v => v.LicensePlate.Value.Equals(licensePlate, StringComparison.OrdinalIgnoreCase));

               if (vehicle == null)
               {
                    throw new KeyNotFoundException($"Vehicle with license plate {licensePlate} not found.");
               }

               return _mapper.Map<VehicleDTO>(vehicle);
          }

          public async Task<List<VehicleDTO>> GetVehiclesBySupplierIdAsync(Guid supplierId)
          {
               var vehicles = await _context.Vehicles
                   .ToListAsync();

               var filteredVehicles = vehicles
                   .Where(v => v.SupplierId.Value == supplierId)
                   .ToList();

               return _mapper.Map<List<VehicleDTO>>(filteredVehicles);
          }

          public async Task<VehicleDTO?> GetVehicleByDriverIdAsync(Guid driverId)
          {
               var vehicles = await _context.Vehicles
                   .Where(v => v.DriverId != null)
                   .ToListAsync();

               var vehicle = vehicles.FirstOrDefault(v => v.DriverId != null && v.DriverId.Value == driverId);

               return vehicle != null ? _mapper.Map<VehicleDTO>(vehicle) : null;
          }

          public async Task<List<VehicleDTO>> GetVehiclesByDriverIdIsNotNullAsync()
          {
               var vehicles = await _context.Vehicles
                   .Where(v => v.DriverId != null)
                   .ToListAsync();

               return _mapper.Map<List<VehicleDTO>>(vehicles);
          }

          public async Task AddVehicleAsync(VehicleDTO vehicleDto)
          {
               var vehicle = _mapper.Map<Domain.AggregateRoot.Vehicle>(vehicleDto);
               _context.Vehicles.Add(vehicle);
               await _context.SaveChangesAsync();
          }

          public async Task UpdateVehicleAsync(VehicleDTO vehicleDto)
          {
               var vehicle = await _context.Vehicles
                   .FirstOrDefaultAsync(v => v.Id == new VehicleId(vehicleDto.VehicleId));

               if (vehicle == null)
               {
                    throw new KeyNotFoundException($"Vehicle with ID {vehicleDto.VehicleId} not found.");
               }

               _mapper.Map(vehicleDto, vehicle);
               _context.Vehicles.Update(vehicle);
               await _context.SaveChangesAsync();
          }
     }
}