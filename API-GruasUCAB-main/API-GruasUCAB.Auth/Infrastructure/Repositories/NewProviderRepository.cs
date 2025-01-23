namespace API_GruasUCAB.Auth.Infrastructure.Repositories
{
     public class NewProviderRepository : Repository<NewProvider>, INewProviderRepository
     {
          public NewProviderRepository(AuthDbContext context) : base(context)
          {
          }

          public async Task<Guid?> GetSupplierIdByUserId(Guid userId)
          {
               var provider = await _context.NewProviders.FirstOrDefaultAsync(p => p.ProviderId == userId);
               if (provider == null)
               {
                    throw new Exception("SupplierId not found for the given UserId");
               }
               return provider.SupplierId;
          }
     }
}