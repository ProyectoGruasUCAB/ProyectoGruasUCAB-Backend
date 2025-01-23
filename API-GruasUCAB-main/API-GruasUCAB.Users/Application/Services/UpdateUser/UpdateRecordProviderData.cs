namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public class UpdateRecordProviderData : IUpdateRecordProviderData
     {
          private readonly IProviderFactory _providerFactory;
          private readonly IProviderRepository _providerRepository;

          public UpdateRecordProviderData(IProviderFactory providerFactory, IProviderRepository providerRepository)
          {
               _providerFactory = providerFactory;
               _providerRepository = providerRepository;
          }

          public async Task<UpdateRecordUserDataResponseDTO> Execute(UpdateRecordUserDataRequestDTO request)
          {
               var providerDTO = await _providerRepository.GetProviderByIdAsync(request.UserId);
               var providerEntity = providerDTO.ToEntity();
               ApplyChanges(providerEntity, request);
               var updatedProviderDTO = providerEntity.ToDTO();
               await _providerRepository.UpdateProviderAsync(updatedProviderDTO);

               return new UpdateRecordUserDataResponseDTO
               {
                    Success = true,
                    Message = "Provider updated successfully",
                    UserEmail = request.UserEmail,
                    UserId = request.UserId
               };
          }

          private void ApplyChanges(Provider provider, UpdateRecordUserDataRequestDTO request)
          {
               if (!string.IsNullOrEmpty(request.Name))
               {
                    provider.ChangeName(new UserName(request.Name));
                    provider.AddDomainEvent(new UserNameChangedEvent(provider.Id, new UserName(request.Name)));
               }

               if (!string.IsNullOrEmpty(request.Phone))
               {
                    provider.ChangePhone(new UserPhone(request.Phone));
                    provider.AddDomainEvent(new UserPhoneChangedEvent(provider.Id, new UserPhone(request.Phone)));
               }

               if (!string.IsNullOrEmpty(request.BirthDate))
               {
                    provider.ChangeBirthDate(new UserBirthDate(request.BirthDate));
                    provider.AddDomainEvent(new UserBirthDateChangedEvent(provider.Id, new UserBirthDate(request.BirthDate)));
               }
          }
     }
}