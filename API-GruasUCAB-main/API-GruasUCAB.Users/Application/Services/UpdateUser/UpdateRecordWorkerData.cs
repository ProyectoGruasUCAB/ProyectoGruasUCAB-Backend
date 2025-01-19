namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public class UpdateRecordWorkerData : IUpdateRecordWorkerData
     {
          private readonly IWorkerFactory _workerFactory;
          private readonly IWorkerRepository _workerRepository;

          public UpdateRecordWorkerData(IWorkerFactory workerFactory, IWorkerRepository workerRepository)
          {
               _workerFactory = workerFactory;
               _workerRepository = workerRepository;
          }

          public async Task<UpdateRecordUserDataResponseDTO> Execute(UpdateRecordUserDataRequestDTO request)
          {
               var worker = await _workerFactory.GetWorkerById(new UserId(request.UserId.ToString()));
               ApplyChanges(worker, request);
               await _workerRepository.UpdateWorkerAsync(worker.ToDTO());

               return new UpdateRecordUserDataResponseDTO
               {
                    Success = true,
                    Message = "Worker updated successfully",
                    UserEmail = request.UserEmail,
                    UserId = request.UserId
               };
          }

          private void ApplyChanges(Worker worker, UpdateRecordUserDataRequestDTO request)
          {
               if (!string.IsNullOrEmpty(request.Name))
               {
                    worker.ChangeName(new UserName(request.Name));
                    worker.AddDomainEvent(new UserNameChangedEvent(worker.Id, new UserName(request.Name)));
               }

               if (!string.IsNullOrEmpty(request.Phone))
               {
                    worker.ChangePhone(new UserPhone(request.Phone));
                    worker.AddDomainEvent(new UserPhoneChangedEvent(worker.Id, new UserPhone(request.Phone)));
               }

               if (!string.IsNullOrEmpty(request.BirthDate))
               {
                    worker.ChangeBirthDate(new UserBirthDate(request.BirthDate));
                    worker.AddDomainEvent(new UserBirthDateChangedEvent(worker.Id, new UserBirthDate(request.BirthDate)));
               }

               if (!string.IsNullOrEmpty(request.Position))
               {
                    worker.ChangePosition(new UserPosition(request.Position));
                    worker.AddDomainEvent(new UserPositionChangedEvent(worker.Id, new UserPosition(request.Position)));
               }

               if (request.WorkplaceId.HasValue)
               {
                    worker.ChangeDepartmentId(new DepartmentId(request.WorkplaceId.Value));
                    worker.AddDomainEvent(new DepartmentIdChangedEvent(worker.Id, new DepartmentId(request.WorkplaceId.Value)));
               }
          }
     }
}