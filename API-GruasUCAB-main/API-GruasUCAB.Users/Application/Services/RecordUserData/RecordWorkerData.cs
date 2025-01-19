namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public class RecordWorkerData : IRecordWorkerData
     {
          private readonly IWorkerFactory _workerFactory;
          private readonly IWorkerRepository _workerRepository;

          public RecordWorkerData(IWorkerFactory workerFactory, IWorkerRepository workerRepository)
          {
               _workerFactory = workerFactory;
               _workerRepository = workerRepository;
          }

          public async Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request)
          {
               if (request.Position == null)
                    throw new ArgumentNullException(nameof(request.Position));
               if (!request.WorkplaceId.HasValue)
                    throw new ArgumentNullException(nameof(request.WorkplaceId), "WorkplaceId is required for workers.");

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

               var workerDTO = worker.ToDTO();
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