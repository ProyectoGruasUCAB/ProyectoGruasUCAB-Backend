namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public class RecordAdministratorData : IRecordAdministratorData
     {
          private readonly IAdministratorFactory _administratorFactory;
          private readonly IAdministratorRepository _administratorRepository;
          private readonly IMapper _mapper;

          public RecordAdministratorData(IAdministratorFactory administratorFactory, IAdministratorRepository administratorRepository, IMapper mapper)
          {
               _administratorFactory = administratorFactory;
               _administratorRepository = administratorRepository;
               _mapper = mapper;
          }

          public async Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request)
          {
               var administrator = _administratorFactory.CreateAdministrator(
                   new UserId(request.UserId),
                   new UserName(request.Name),
                   new UserEmail(request.UserEmail),
                   new UserPhone(request.Phone),
                   new UserCedula(request.Cedula),
                   new UserBirthDate(request.BirthDate)
               );

               var administratorDTO = _mapper.Map<AdministratorDTO>(administrator);
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