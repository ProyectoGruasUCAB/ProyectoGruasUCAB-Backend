namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public class RecordWorkerData : IRecordWorkerData
     {
          private readonly IWorkerFactory _workerFactory;
          private readonly IWorkerRepository _workerRepository;
          private readonly IDepartmentRepository _departmentRepository;
          private readonly INewWorkerRepository _newWorkerRepository;
          private readonly IMapper _mapper;

          public RecordWorkerData(IWorkerFactory workerFactory, IWorkerRepository workerRepository, IDepartmentRepository departmentRepository, INewWorkerRepository newWorkerRepository, IMapper mapper)
          {
               _workerFactory = workerFactory;
               _workerRepository = workerRepository;
               _departmentRepository = departmentRepository;
               _newWorkerRepository = newWorkerRepository;
               _mapper = mapper;
          }

          public async Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request)
          {
               var departmentAndPosition = await _newWorkerRepository.GetDepartmentAndPositionByUserId(request.UserId);
               if (departmentAndPosition == null)
               {
                    return new RecordUserDataResponseDTO
                    {
                         Success = false,
                         Message = "DepartmentId and Position not found for the given UserId",
                         UserEmail = request.UserEmail,
                         UserId = request.UserId
                    };
               }

               var (departmentId, position) = departmentAndPosition.Value;
               var department = await _departmentRepository.GetDepartmentByIdAsync(departmentId);
               if (department == null)
               {
                    return new RecordUserDataResponseDTO
                    {
                         Success = false,
                         Message = "Department does not exist",
                         UserEmail = request.UserEmail,
                         UserId = request.UserId
                    };
               }

               var worker = _workerFactory.CreateWorker(
                   new UserId(request.UserId),
                   new UserName(request.Name),
                   new UserEmail(request.UserEmail),
                   new UserPhone(request.Phone),
                   new UserCedula(request.Cedula),
                   new UserBirthDate(request.BirthDate),
                   new UserPosition(position),
                   new DepartmentId(departmentId)
               );

               var workerDTO = _mapper.Map<WorkerDTO>(worker);
               await _workerRepository.AddWorkerAsync(workerDTO);

               return new RecordUserDataResponseDTO
               {
                    Success = true,
                    Message = "Worker created successfully",
                    UserEmail = request.UserEmail,
                    UserId = request.UserId
               };
          }
     }
}