namespace API_GruasUCAB.Users.Domain.Factories
{
     public interface IWorkerFactory
     {
          Worker CreateWorker(
              UserId id,
              UserName name,
              UserEmail email,
              UserPhone phone,
              UserCedula cedula,
              UserBirthDate birthDate,
              UserPosition position);

          Task<Worker> GetWorkerById(UserId id);
     }
}