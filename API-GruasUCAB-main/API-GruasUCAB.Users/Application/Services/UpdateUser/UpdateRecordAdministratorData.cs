namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public class UpdateRecordAdministratorData : IUpdateRecordAdministratorData
     {
          private readonly IAdministratorFactory _administratorFactory;
          private readonly IAdministratorRepository _administratorRepository;

          public UpdateRecordAdministratorData(IAdministratorFactory administratorFactory, IAdministratorRepository administratorRepository)
          {
               _administratorFactory = administratorFactory;
               _administratorRepository = administratorRepository;
          }

          public async Task<UpdateRecordUserDataResponseDTO> Execute(UpdateRecordUserDataRequestDTO request)
          {
               var administrator = await _administratorFactory.GetAdministratorById(new UserId(request.UserId.ToString()));
               ApplyChanges(administrator, request);
               await _administratorRepository.UpdateAdministratorAsync(administrator.ToDTO());

               return new UpdateRecordUserDataResponseDTO
               {
                    Success = true,
                    Message = "Administrator updated successfully",
                    UserEmail = request.UserEmail,
                    UserId = request.UserId
               };
          }

          private void ApplyChanges(Administrator admin, UpdateRecordUserDataRequestDTO request)
          {
               if (!string.IsNullOrEmpty(request.Name))
               {
                    admin.ChangeName(new UserName(request.Name));
                    admin.AddDomainEvent(new UserNameChangedEvent(admin.Id, new UserName(request.Name)));
               }

               if (!string.IsNullOrEmpty(request.Phone))
               {
                    admin.ChangePhone(new UserPhone(request.Phone));
                    admin.AddDomainEvent(new UserPhoneChangedEvent(admin.Id, new UserPhone(request.Phone)));
               }

               if (!string.IsNullOrEmpty(request.BirthDate))
               {
                    admin.ChangeBirthDate(new UserBirthDate(request.BirthDate));
                    admin.AddDomainEvent(new UserBirthDateChangedEvent(admin.Id, new UserBirthDate(request.BirthDate)));
               }
          }
     }
}