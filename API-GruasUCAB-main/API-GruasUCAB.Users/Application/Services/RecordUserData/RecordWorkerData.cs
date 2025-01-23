namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public class RecordWorkerData : IRecordWorkerData
     {
          private readonly IWorkerFactory _workerFactory;
          private readonly IWorkerRepository _workerRepository;
          private readonly IDepartmentRepository _departmentRepository;
          private readonly IMapper _mapper;

          public RecordWorkerData(IWorkerFactory workerFactory, IWorkerRepository workerRepository, IDepartmentRepository departmentRepository, IMapper mapper)
          {
               _workerFactory = workerFactory;
               _workerRepository = workerRepository;
               _departmentRepository = departmentRepository;
               _mapper = mapper;
          }

          public async Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request)
          {
               if (request.Position == null)
                    throw new ArgumentNullException(nameof(request.Position));
               if (!request.WorkplaceId.HasValue)
                    throw new ArgumentNullException(nameof(request.WorkplaceId), "WorkplaceId is required for workers.");

               var department = await _departmentRepository.GetDepartmentByIdAsync(request.WorkplaceId.Value);
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
                   new UserPosition(request.Position),
                   new DepartmentId(request.WorkplaceId.Value)
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