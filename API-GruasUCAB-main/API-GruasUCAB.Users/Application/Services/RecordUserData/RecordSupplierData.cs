namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public class RecordSupplierData : IRecordSupplierData
     {
          private readonly ISupplierFactory _supplierFactory;
          private readonly IProviderRepository _providerRepository;

          public RecordSupplierData(ISupplierFactory supplierFactory, IProviderRepository providerRepository)
          {
               _supplierFactory = supplierFactory;
               _providerRepository = providerRepository;
          }

          public async Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request)
          {
               var supplier = _supplierFactory.CreateSupplier(
                   new UserId(request.UserId.ToString()),
                   new UserName(request.Name),
                   new UserEmail(request.UserEmail),
                   new UserPhone(request.Phone),
                   new UserCedula(request.Cedula),
                   new UserBirthDate(request.BirthDate)
               );

               var providerDTO = new ProviderDTO
               {
                    Id = request.UserId,
                    Name = request.Name,
                    UserEmail = request.UserEmail,
                    Phone = request.Phone,
                    Cedula = request.Cedula,
                    BirthDate = request.BirthDate
               };

               await _providerRepository.AddProviderAsync(providerDTO);

               return new RecordUserDataResponseDTO
               {
                    Success = true,
                    Message = "Supplier created successfully",
                    UserEmail = request.UserEmail,
                    UserId = request.UserId
               };
          }
     }
}