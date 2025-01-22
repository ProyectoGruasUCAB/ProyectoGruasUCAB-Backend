namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public class RecordProviderData : IRecordProviderData
     {
          private readonly IProviderFactory _providerFactory;
          private readonly IProviderRepository _providerRepository;
          private readonly ISupplierRepository _supplierRepository;

          public RecordProviderData(IProviderFactory providerFactory, IProviderRepository providerRepository, ISupplierRepository supplierRepository)
          {
               _providerFactory = providerFactory;
               _providerRepository = providerRepository;
               _supplierRepository = supplierRepository;
          }

          public async Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request)
          {
               if (!request.WorkplaceId.HasValue)
               {
                    throw new ArgumentNullException(nameof(request.WorkplaceId), "WorkplaceId is required for providers.");
               }

               var supplier = await _supplierRepository.GetSupplierByIdAsync(request.WorkplaceId.Value);
               if (supplier == null)
               {
                    return new RecordUserDataResponseDTO
                    {
                         Success = false,
                         Message = "Supplier does not exist",
                         UserEmail = request.UserEmail,
                         UserId = request.UserId
                    };
               }

               var provider = _providerFactory.CreateProvider(
                   new UserId(request.UserId),
                   new UserName(request.Name),
                   new UserEmail(request.UserEmail),
                   new UserPhone(request.Phone),
                   new UserCedula(request.Cedula),
                   new UserBirthDate(request.BirthDate),
                   new SupplierId(request.WorkplaceId.Value)
               );

               var providerDTO = provider.ToDTO();
               await _providerRepository.AddProviderAsync(providerDTO);

               return new RecordUserDataResponseDTO
               {
                    Success = true,
                    Message = "Provider created successfully",
                    UserEmail = request.UserEmail,
                    UserId = request.UserId
               };
          }
     }
}