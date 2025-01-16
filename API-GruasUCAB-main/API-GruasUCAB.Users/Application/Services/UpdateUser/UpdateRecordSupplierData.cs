namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public class UpdateRecordSupplierData : IUpdateRecordSupplierData
     {
          private readonly ISupplierFactory _supplierFactory;
          private readonly IProviderRepository _providerRepository;

          public UpdateRecordSupplierData(ISupplierFactory supplierFactory, IProviderRepository providerRepository)
          {
               _supplierFactory = supplierFactory;
               _providerRepository = providerRepository;
          }

          public async Task<UpdateRecordUserDataResponseDTO> Execute(UpdateRecordUserDataRequestDTO request)
          {
               var supplier = await _supplierFactory.GetSupplierById(new UserId(request.UserId.ToString()));
               ApplyChanges(supplier, request);
               await _providerRepository.UpdateProviderAsync(supplier.ToDTO());

               return new UpdateRecordUserDataResponseDTO
               {
                    Success = true,
                    Message = "Supplier updated successfully",
                    UserEmail = request.UserEmail,
                    UserId = request.UserId
               };
          }

          private void ApplyChanges(Supplier supplier, UpdateRecordUserDataRequestDTO request)
          {
               if (!string.IsNullOrEmpty(request.Name))
               {
                    supplier.ChangeName(new UserName(request.Name));
                    supplier.AddDomainEvent(new UserNameChangedEvent(supplier.Id, new UserName(request.Name)));
               }

               if (!string.IsNullOrEmpty(request.Phone))
               {
                    supplier.ChangePhone(new UserPhone(request.Phone));
                    supplier.AddDomainEvent(new UserPhoneChangedEvent(supplier.Id, new UserPhone(request.Phone)));
               }

               if (!string.IsNullOrEmpty(request.BirthDate))
               {
                    supplier.ChangeBirthDate(new UserBirthDate(request.BirthDate));
                    supplier.AddDomainEvent(new UserBirthDateChangedEvent(supplier.Id, new UserBirthDate(request.BirthDate)));
               }
          }
     }
}