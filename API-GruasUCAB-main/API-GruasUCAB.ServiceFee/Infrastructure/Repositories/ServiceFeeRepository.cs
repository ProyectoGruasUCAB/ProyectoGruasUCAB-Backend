namespace API_GruasUCAB.ServiceFee.Infrastructure.Repositories
{
     public class ServiceFeeRepository : IServiceFeeRepository
     {
          private readonly ServiceFeeDbContext _context;
          private readonly IMapper _mapper;

          public ServiceFeeRepository(ServiceFeeDbContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }

          public async Task<List<ServiceFeeDTO>> GetAllServiceFeesAsync()
          {
               var serviceFees = await _context.ServiceFees.ToListAsync();
               return _mapper.Map<List<ServiceFeeDTO>>(serviceFees);
          }

          public async Task<ServiceFeeDTO> GetServiceFeeByIdAsync(Guid id)
          {
               var serviceFee = await _context.ServiceFees
                   .FirstOrDefaultAsync(sf => sf.Id == new ServiceFeeId(id));

               if (serviceFee == null)
               {
                    throw new KeyNotFoundException($"Service fee with ID {id} not found.");
               }

               return _mapper.Map<ServiceFeeDTO>(serviceFee);
          }

          public async Task<List<ServiceFeeDTO>> GetServiceFeeByNameAsync(string name)
          {
               var serviceFees = await _context.ServiceFees
                   .ToListAsync();

               var filteredServiceFees = serviceFees
                   .Where(sf => sf.Name.Value.Contains(name, StringComparison.OrdinalIgnoreCase))
                   .ToList();

               if (!filteredServiceFees.Any())
               {
                    throw new KeyNotFoundException($"No service fees with name containing '{name}' found.");
               }

               return _mapper.Map<List<ServiceFeeDTO>>(filteredServiceFees);
          }

          public async Task AddServiceFeeAsync(ServiceFeeDTO serviceFeeDto)
          {
               var serviceFee = new Domain.AggregateRoot.ServiceFee(
                   new ServiceFeeId(serviceFeeDto.ServiceFeeId),
                   new ServiceFeeName(serviceFeeDto.Name),
                   new ServiceFeePrice(serviceFeeDto.Price),
                   new ServiceFeePriceKm(serviceFeeDto.PriceKm),
                   new ServiceFeeRadius(serviceFeeDto.Radius),
                   new ServiceFeeDescription(serviceFeeDto.Description)
               );

               _context.ServiceFees.Add(serviceFee);
               await _context.SaveChangesAsync();
          }

          public async Task UpdateServiceFeeAsync(ServiceFeeDTO serviceFeeDto)
          {
               var serviceFee = await _context.ServiceFees
                    .FirstOrDefaultAsync(sf => sf.Id == new ServiceFeeId(serviceFeeDto.ServiceFeeId));

               if (serviceFee == null)
               {
                    throw new KeyNotFoundException($"Service fee with ID {serviceFeeDto.ServiceFeeId} not found.");
               }

               serviceFee.ChangeName(new ServiceFeeName(serviceFeeDto.Name));
               serviceFee.ChangePrice(new ServiceFeePrice(serviceFeeDto.Price));
               serviceFee.ChangePriceKm(new ServiceFeePriceKm(serviceFeeDto.PriceKm));
               serviceFee.ChangeRadius(new ServiceFeeRadius(serviceFeeDto.Radius));
               serviceFee.ChangeDescription(new ServiceFeeDescription(serviceFeeDto.Description));

               _context.ServiceFees.Update(serviceFee);
               await _context.SaveChangesAsync();
          }
     }
}