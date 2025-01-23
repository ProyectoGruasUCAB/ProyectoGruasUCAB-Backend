namespace API_GruasUCAB.Auth.Infrastructure.Repositories
{
     public class NewDriverRepository : Repository<NewDriver>, INewDriverRepository
     {
          public NewDriverRepository(AuthDbContext context) : base(context)
          {
          }

          public async Task<Guid> GetSupplierIdByUserId(Guid userId)
          {
               var driver = await _context.NewDrivers.FirstOrDefaultAsync(d => d.DriverId == userId);
               if (driver == null)
               {
                    throw new Exception("SupplierId not found for the given UserId");
               }
               return driver.SupplierId;
          }
     }
}