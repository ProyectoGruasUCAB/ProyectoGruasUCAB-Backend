namespace API_GruasUCAB.Vehicle.Infrastructure.Repositories
{
     public class VehicleRepository : IVehicleRepository
     {
          private readonly List<VehicleDTO> _vehicles;

          public VehicleRepository()
          {
               // Inicializar la lista con datos de ejemplo
               _vehicles = new List<VehicleDTO>
            {
                new VehicleDTO
                {
                    VehicleId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    DriverId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    SupplierId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    CivilLiability = "Liability A",
                    CivilLiabilityExpirationDate = "2023-12-31",
                    TrafficLicense = "License A",
                    LicensePlate = "ABC123",
                    Brand = "Brand A",
                    Color = "Red",
                    Model = "Model A",
                    VehicleTypeId = Guid.Parse("44444444-4444-4444-4444-444444444444")
                },
                new VehicleDTO
                {
                    VehicleId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    DriverId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    SupplierId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    CivilLiability = "Liability B",
                    CivilLiabilityExpirationDate = "2024-12-31",
                    TrafficLicense = "License B",
                    LicensePlate = "DEF456",
                    Brand = "Brand B",
                    Color = "Blue",
                    Model = "Model B",
                    VehicleTypeId = Guid.Parse("88888888-8888-8888-8888-888888888888")
                },
                new VehicleDTO
                {
                    VehicleId = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                    DriverId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                    SupplierId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    CivilLiability = "Liability C",
                    CivilLiabilityExpirationDate = "2025-12-31",
                    TrafficLicense = "License C",
                    LicensePlate = "GHI789",
                    Brand = "Brand C",
                    Color = "Green",
                    Model = "Model C",
                    VehicleTypeId = Guid.Parse("22222222-2222-2222-2222-222222222222")
                }
            };
          }

          public async Task<List<VehicleDTO>> GetAllVehiclesAsync()
          {
               // Simulación de una llamada a la base de datos
               return await Task.FromResult(_vehicles);
          }

          public async Task<VehicleDTO> GetVehicleByIdAsync(Guid id)
          {
               // Simulación de una llamada a la base de datos
               var vehicle = _vehicles.FirstOrDefault(v => v.VehicleId == id);
               if (vehicle == null)
               {
                    throw new KeyNotFoundException($"Vehicle with ID {id} not found.");
               }
               return await Task.FromResult(vehicle);
          }

          public async Task<VehicleDTO> GetVehicleByLicensePlateAsync(string licensePlate)
          {
               // Simulación de una llamada a la base de datos
               var vehicle = _vehicles.FirstOrDefault(v => v.LicensePlate.Equals(licensePlate, StringComparison.OrdinalIgnoreCase));
               if (vehicle == null)
               {
                    throw new KeyNotFoundException($"Vehicle with license plate {licensePlate} not found.");
               }
               return await Task.FromResult(vehicle);
          }
     }
}