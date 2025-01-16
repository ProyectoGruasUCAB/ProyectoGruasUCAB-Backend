namespace API_GruasUCAB.Users.Domain.Factories
{
     public class WorkerFactory : IWorkerFactory
     {
          private readonly IWorkerRepository _workerRepository;

          public WorkerFactory(IWorkerRepository workerRepository)
          {
               _workerRepository = workerRepository;
          }

          public Worker CreateWorker(
              UserId id,
              UserName name,
              UserEmail email,
              UserPhone phone,
              UserCedula cedula,
              UserBirthDate birthDate,
              UserPosition position)
          {
               return new Worker(id, name, email, phone, cedula, birthDate, position);
          }

          public async Task<Worker> GetWorkerById(UserId id)
          {
               var workerDTO = await _workerRepository.GetWorkerByIdAsync(id.Id);
               return new Worker(
                   new UserId(workerDTO.Id),
                   new UserName(workerDTO.Name),
                   new UserEmail(workerDTO.UserEmail),
                   new UserPhone(workerDTO.Phone),
                   new UserCedula(workerDTO.Cedula),
                   new UserBirthDate(workerDTO.BirthDate),
                   new UserPosition(workerDTO.Position)
               );
          }
     }
}