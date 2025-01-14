namespace API_GruasUCAB.Users.Domain.Factories
{
     public class WorkerFactory : IWorkerFactory
     {
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
     }
}