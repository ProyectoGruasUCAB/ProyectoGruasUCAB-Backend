namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public class RecordAdministratorData : IRecordUserData
     {
          private readonly IAdministratorFactory _administratorFactory;
          private readonly IAdministratorRepository _administratorRepository;

          public RecordAdministratorData(IAdministratorFactory administratorFactory, IAdministratorRepository administratorRepository)
          {
               _administratorFactory = administratorFactory;
               _administratorRepository = administratorRepository;
          }

          public async Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request)
          {
               var administrator = _administratorFactory.CreateAdministrator(
                   new UserId(request.UserId.ToString()),
                   new UserName(request.Name),
                   new UserEmail(request.UserEmail),
                   new UserPhone(request.Phone),
                   new UserCedula(request.Cedula),
                   new UserBirthDate(request.BirthDate)
               );

               var administratorDTO = new AdministratorDTO
               {
                    UserId = request.UserId,
                    Name = request.Name,
                    Email = request.UserEmail,
                    Phone = request.Phone,
                    Cedula = request.Cedula,
                    BirthDate = request.BirthDate
               };

               await _administratorRepository.AddAdministratorAsync(administratorDTO);

               return new RecordUserDataResponseDTO
               {
                    Success = true,
                    Message = "Administrator created successfully",
                    UserEmail = request.UserEmail,
                    UserId = request.UserId
               };
          }
     }
}