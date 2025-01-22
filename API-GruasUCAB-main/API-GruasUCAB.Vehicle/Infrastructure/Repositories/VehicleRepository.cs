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

               var vehicleDto = _mapper.Map<VehicleDTO>(vehicle);

               if (!DateTime.TryParseExact(vehicleDto.CivilLiabilityExpirationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
               {
                    throw new ArgumentException($"Invalid Vehicle Civil Liability Expiration Date format: {vehicleDto.CivilLiabilityExpirationDate}");
               }

               vehicleDto.CivilLiabilityExpirationDate = parsedDate.ToString("dd-MM-yyyy");

               return vehicleDto;
          }

          public async Task<VehicleDTO> GetVehicleByLicensePlateAsync(string licensePlate)
          {
               var vehicles = await _context.Vehicles.ToListAsync();
               var vehicle = vehicles
                   .FirstOrDefault(v => v.LicensePlate.Value.Equals(licensePlate, StringComparison.OrdinalIgnoreCase));

               if (vehicle == null)
               {
                    throw new KeyNotFoundException($"Vehicle with license plate {licensePlate} not found.");
               }

               var vehicleDto = _mapper.Map<VehicleDTO>(vehicle);

               if (!DateTime.TryParseExact(vehicleDto.CivilLiabilityExpirationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
               {
                    throw new ArgumentException($"Invalid Vehicle Civil Liability Expiration Date format: {vehicleDto.CivilLiabilityExpirationDate}");
               }

               vehicleDto.CivilLiabilityExpirationDate = parsedDate.ToString("dd-MM-yyyy");

               return vehicleDto;
          }

          public async Task AddVehicleAsync(VehicleDTO vehicleDto)
          {
               if (!DateTime.TryParseExact(vehicleDto.CivilLiabilityExpirationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
               {
                    throw new ArgumentException($"Invalid Vehicle Civil Liability Expiration Date format: {vehicleDto.CivilLiabilityExpirationDate}");
               }

               var vehicle = new Domain.AggregateRoot.Vehicle(
                   new VehicleId(vehicleDto.VehicleId),
                   new VehicleCivilLiability(vehicleDto.CivilLiability),
                   new VehicleCivilLiabilityExpirationDate(parsedDate.ToString("dd-MM-yyyy")),
                   new VehicleTrafficLicense(vehicleDto.TrafficLicense),
                   new VehicleLicensePlate(vehicleDto.LicensePlate),
                   new VehicleBrand(vehicleDto.Brand),
                   new VehicleColor(vehicleDto.Color),
                   new VehicleModel(vehicleDto.Model),
                   new VehicleTypeId(vehicleDto.VehicleTypeId),
                   vehicleDto.DriverId != null ? new UserId(vehicleDto.DriverId.Value) : null,
                   new SupplierId(vehicleDto.SupplierId)
               );

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

               if (!DateTime.TryParseExact(vehicleDto.CivilLiabilityExpirationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
               {
                    throw new ArgumentException($"Invalid Vehicle Civil Liability Expiration Date format: {vehicleDto.CivilLiabilityExpirationDate}");
               }

               vehicle.ChangeCivilLiability(new VehicleCivilLiability(vehicleDto.CivilLiability));
               vehicle.ChangeCivilLiabilityExpirationDate(new VehicleCivilLiabilityExpirationDate(parsedDate.ToString("dd-MM-yyyy")));
               vehicle.ChangeTrafficLicense(new VehicleTrafficLicense(vehicleDto.TrafficLicense));
               vehicle.ChangeLicensePlate(new VehicleLicensePlate(vehicleDto.LicensePlate));
               vehicle.ChangeBrand(new VehicleBrand(vehicleDto.Brand));
               vehicle.ChangeColor(new VehicleColor(vehicleDto.Color));
               vehicle.ChangeModel(new VehicleModel(vehicleDto.Model));
               vehicle.ChangeVehicleTypeId(new VehicleTypeId(vehicleDto.VehicleTypeId));
               vehicle.ChangeDriverId(vehicleDto.DriverId != null ? new UserId(vehicleDto.DriverId.Value) : null);

               _context.Vehicles.Update(vehicle);
               await _context.SaveChangesAsync();
          }
     }
}