namespace API_GruasUCAB.Vehicle.Infrastructure.Repositories
{
     public class VehicleTypeRepository : IVehicleTypeRepository
     {
          private readonly VehicleDbContext _context;
          private readonly IMapper _mapper;

          public VehicleTypeRepository(VehicleDbContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }

          public async Task<List<VehicleTypeDTO>> GetAllVehicleTypesAsync()
          {
               var vehicleTypes = await _context.VehicleTypes.ToListAsync();
               return _mapper.Map<List<VehicleTypeDTO>>(vehicleTypes);
          }

          public async Task<VehicleTypeDTO> GetVehicleTypeByIdAsync(Guid id)
          {
               var vehicleTypes = await _context.VehicleTypes.ToListAsync();
               var vehicleType = vehicleTypes
                   .FirstOrDefault(vt => vt.Id.Value == id);

               if (vehicleType == null)
               {
                    throw new KeyNotFoundException($"VehicleType with ID {id} not found.");
               }

               return _mapper.Map<VehicleTypeDTO>(vehicleType);
          }

          public async Task<VehicleTypeDTO> GetVehicleTypeByNameAsync(string name)
          {
               var vehicleTypes = await _context.VehicleTypes.ToListAsync();
               var vehicleType = vehicleTypes
                   .FirstOrDefault(vt => vt.Type.ToString().Equals(name, StringComparison.OrdinalIgnoreCase));

               if (vehicleType == null)
               {
                    throw new KeyNotFoundException($"VehicleType with name {name} not found.");
               }

               return _mapper.Map<VehicleTypeDTO>(vehicleType);
          }

          public async Task AddVehicleTypeAsync(VehicleTypeDTO vehicleTypeDto)
          {
               var vehicleType = new VehicleType(
                   new VehicleTypeId(vehicleTypeDto.VehicleTypeId),
                   Enum.Parse<VehicleTypeEnumerate>(vehicleTypeDto.Name),
                   new DescripcionVehicleType(vehicleTypeDto.Description)
               );

               _context.VehicleTypes.Add(vehicleType);
               await _context.SaveChangesAsync();
          }

          public async Task UpdateVehicleTypeAsync(VehicleTypeDTO vehicleTypeDto)
          {
               var vehicleTypes = await _context.VehicleTypes.ToListAsync();
               var vehicleType = vehicleTypes
                   .FirstOrDefault(vt => vt.Id.Value == vehicleTypeDto.VehicleTypeId);

               if (vehicleType == null)
               {
                    throw new KeyNotFoundException($"VehicleType with ID {vehicleTypeDto.VehicleTypeId} not found.");
               }

               vehicleType.ChangeType(Enum.Parse<VehicleTypeEnumerate>(vehicleTypeDto.Name));
               vehicleType.ChangeDescripcionVehicleType(new DescripcionVehicleType(vehicleTypeDto.Description));

               _context.VehicleTypes.Update(vehicleType);
               await _context.SaveChangesAsync();
          }
     }
}