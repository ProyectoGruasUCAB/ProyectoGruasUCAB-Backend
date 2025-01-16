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
<<<<<<< HEAD

          public async Task<Worker> GetWorkerById(UserId id)
          {
               // Implementa la lógica para obtener el trabajador por su ID
               // Esto puede involucrar una llamada a un repositorio o una base de datos
               // Aquí se usa Task.FromResult como un ejemplo de implementación asincrónica
               return await Task.FromResult(new Worker(
                   id,
                   new UserName("Example Name"),
                   new UserEmail("example@example.com"),
                   new UserPhone("04240000000"),
                   new UserCedula("V-12345678"),
                   new UserBirthDate("01-01-2000"),
                   new UserPosition("Example Position")
               ));
          }
=======
>>>>>>> origin/Development
     }
}