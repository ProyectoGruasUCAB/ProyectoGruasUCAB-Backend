namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public class UpdateRecordUserDataService : IService<UpdateRecordUserDataRequestDTO, UpdateRecordUserDataResponseDTO>
     {
          private readonly IEventStore _eventStore;

          public UpdateRecordUserDataService(IEventStore eventStore)
          {
               _eventStore = eventStore;
          }

          public async Task<UpdateRecordUserDataResponseDTO> Execute(UpdateRecordUserDataRequestDTO request)
          {
               // Recupera los eventos asociados con el usuario
               //var events = await _eventStore.GetEventsByStream(request.Id.ToString());
               var events = new List<IDomainEvent>
               {
                new RecordAdministratorDataEvent(
                    new UserId(request.Id.ToString()),
                    new UserName("InitialName"),
                    new UserEmail("initial@example.com"),
                    new UserPhone("04125615987"),
                    new UserBirthDate("01-01-2000")
                )
               };

               // No lanzar excepción si no hay eventos
               if (events.Count == 0)
               {
                    // Puedes agregar un evento predeterminado si es necesario
                    events.Add(new RecordAdministratorDataEvent(
                        new UserId(request.Id.ToString()),
                        new UserName("DefaultName"),
                        new UserEmail("default@example.com"),
                        new UserPhone("0000000000"),
                        new UserBirthDate("2000-01-2000")
                    ));
               }
               if (events.Count == 0) throw new UserNotFoundException(request.Id);

               // Valida el rol del usuario
               if (!Enum.TryParse(request.Role, out UserRole userRole))
               {
                    return await Task.FromResult(new UpdateRecordUserDataResponseDTO
                    {
                         Success = false,
                         Message = "Invalid user role",
                         UserEmail = request.UserEmail,
                         UserId = Guid.Empty
                    });
               }

               try
               {
                    AggregateRoot<UserId>? user = null;

                    if (userRole == UserRole.Administrador)
                    {
                         // Crear variables "fake" para los valores que no se pueden modificar
                         var fakeId = new UserId(request.Id.ToString());
                         var fakeCedula = new UserCedula("V-28686611");
                         var fakeEmail = new UserEmail(request.UserEmail);

                         var admin = new Administrator(
                            fakeId,
                            new UserName(request.Name ?? "DefaultName"),
                            fakeEmail,
                            new UserPhone(request.Phone ?? "0000000000"),
                            fakeCedula,
                            new UserBirthDate(request.BirthDate ?? "2000-01-01")
                        );

                         // Aplica manualmente los eventos para reconstruir el estado del administrador
                         foreach (var @event in events)
                         {
                              ApplyEvent(admin, @event);
                         }

                         // Aplica los cambios solicitados
                         ApplyChanges(admin, request);

                         user = admin;
                    }
                    else if (userRole == UserRole.Conductor)
                    {
                         // Crear variables "fake" para los valores que no se pueden modificar
                         var fakeId = new UserId(request.Id.ToString());
                         var fakeCedula = new UserCedula("V-28686611");
                         var fakeEmail = new UserEmail(request.UserEmail);

                         var driver = new Driver(
                             fakeId,
                             new UserName(request.Name ?? "DefaultName"),
                             fakeEmail,
                             new UserPhone(request.Phone ?? "0000000000"),
                             fakeCedula,
                             new UserBirthDate(request.BirthDate ?? "2000-01-01"),
                             new UserCedulaExpirationDate(request.CedulaExpirationDate ?? "2000-01-01"),
                             new UserMedicalCertificate(request.MedicalCertificate ?? "DefaultCertificate"),
                             new UserMedicalCertificateExpirationDate(request.MedicalCertificateExpirationDate ?? "2000-01-01"),
                             new UserDriverLicense(request.DriverLicense ?? "DefaultLicense"),
                             new UserDriverLicenseExpirationDate(request.DriverLicenseExpirationDate ?? "2000-01-01")
                         );

                         // Aplica manualmente los eventos para reconstruir el estado del conductor
                         foreach (var @event in events)
                         {
                              ApplyEvent(driver, @event);
                         }

                         // Aplica los cambios solicitados
                         ApplyChanges(driver, request);

                         user = driver;
                    }
                    else if (userRole == UserRole.Trabajador)
                    {
                         // Crear variables "fake" para los valores que no se pueden modificar
                         var fakeId = new UserId(request.Id.ToString());
                         var fakeCedula = new UserCedula("V-28686611");
                         var fakeEmail = new UserEmail(request.UserEmail);

                         var worker = new Worker(
                             fakeId,
                             new UserName(request.Name ?? "DefaultName"),
                             fakeEmail,
                             new UserPhone(request.Phone ?? "0000000000"),
                             fakeCedula,
                             new UserBirthDate(request.BirthDate ?? "2000-01-01"),
                             new UserPosition(request.Position ?? "DefaultPosition")
                         );

                         // Aplica manualmente los eventos para reconstruir el estado del trabajador
                         foreach (var @event in events)
                         {
                              ApplyEvent(worker, @event);
                         }

                         // Aplica los cambios solicitados
                         ApplyChanges(worker, request);

                         user = worker;
                    }
                    else if (userRole == UserRole.Proveedor)
                    {
                         // Crear variables "fake" para los valores que no se pueden modificar
                         var fakeId = new UserId(request.Id.ToString());
                         var fakeCedula = new UserCedula("V-28686611");
                         var fakeEmail = new UserEmail(request.UserEmail);

                         var provider = new Supplier(
                             fakeId,
                             new UserName(request.Name ?? "DefaultName"),
                             fakeEmail,
                             new UserPhone(request.Phone ?? "0000000000"),
                             fakeCedula,
                             new UserBirthDate(request.BirthDate ?? "2000-01-01")
                         );

                         // Aplica manualmente los eventos para reconstruir el estado del proveedor
                         foreach (var @event in events)
                         {
                              ApplyEvent(provider, @event);
                         }

                         // Aplica los cambios solicitados
                         ApplyChanges(provider, request);

                         user = provider;
                    }

                    // Genera nuevos eventos a partir de los cambios realizados y los almacena en el EventStore
                    var newEvents = user?.PullEvents() ?? throw new InvalidOperationException("User events could not be pulled.");
                    await _eventStore.AppendEvents(request.Id.ToString(), newEvents);

                    // Obtén los detalles del usuario
                    var userDetails = GetUserDetails(user);
                    return new UpdateRecordUserDataResponseDTO
                    {
                         Success = true,
                         Message = $"User updated successfully. {userDetails}",
                         UserEmail = request.UserEmail,
                         UserId = request.Id
                    };
               }
               catch (Exception ex)
               {
                    return await Task.FromResult(new UpdateRecordUserDataResponseDTO
                    {
                         Success = false,
                         Message = ex.Message,
                         UserEmail = request.UserEmail,
                         UserId = Guid.Empty
                    });
               }
          }

          private string GetUserDetails(AggregateRoot<UserId>? user)
          {
               if (user is Administrator admin)
               {
                    return $"Name: {admin.Name}, Email: {admin.Email}, Phone: {admin.Phone}, Cedula: {admin.Cedula}, BirthDate: {admin.BirthDate}";
               }
               else if (user is Driver driver)
               {
                    return $"Name: {driver.Name}, Email: {driver.Email}, Phone: {driver.Phone}, Cedula: {driver.Cedula}, BirthDate: {driver.BirthDate}, CedulaExpirationDate: {driver.CedulaExpirationDate}, MedicalCertificate: {driver.MedicalCertificate}, MedicalCertificateExpirationDate: {driver.MedicalCertificateExpirationDate}, DriverLicense: {driver.DriverLicense}, DriverLicenseExpirationDate: {driver.DriverLicenseExpirationDate}";
               }
               else if (user is Worker worker)
               {
                    return $"Name: {worker.Name}, Email: {worker.Email}, Phone: {worker.Phone}, Cedula: {worker.Cedula}, BirthDate: {worker.BirthDate}, Position: {worker.Position}";
               }
               else if (user is Supplier provider)
               {
                    return $"Name: {provider.Name}, Email: {provider.Email}, Phone: {provider.Phone}, Cedula: {provider.Cedula}, BirthDate: {provider.BirthDate}";
               }
               return "User details not available.";
          }

          private void ApplyEvent(Administrator admin, IDomainEvent @event)
          {
               if (@event is UserNameChangedEvent nameChangedEvent)
               {
                    admin.ChangeName(nameChangedEvent.NewName);
               }
               else if (@event is UserPhoneChangedEvent phoneChangedEvent)
               {
                    admin.ChangePhone(phoneChangedEvent.NewPhone);
               }
               else if (@event is UserBirthDateChangedEvent birthDateChangedEvent)
               {
                    admin.ChangeBirthDate(birthDateChangedEvent.NewBirthDate);
               }
          }

          private void ApplyEvent(Driver driver, IDomainEvent @event)
          {
               if (@event is UserNameChangedEvent nameChangedEvent)
               {
                    driver.ChangeName(nameChangedEvent.NewName);
               }
               else if (@event is UserPhoneChangedEvent phoneChangedEvent)
               {
                    driver.ChangePhone(phoneChangedEvent.NewPhone);
               }
               else if (@event is UserBirthDateChangedEvent birthDateChangedEvent)
               {
                    driver.ChangeBirthDate(birthDateChangedEvent.NewBirthDate);
               }
               else if (@event is UserCedulaExpirationDateChangedEvent cedulaExpirationDateChangedEvent)
               {
                    driver.ChangeCedulaExpirationDate(cedulaExpirationDateChangedEvent.NewCedulaExpirationDate);
               }
               else if (@event is UserMedicalCertificateChangedEvent medicalCertificateChangedEvent)
               {
                    driver.ChangeMedicalCertificate(medicalCertificateChangedEvent.NewMedicalCertificate);
               }
               else if (@event is UserDriverLicenseChangedEvent driverLicenseChangedEvent)
               {
                    driver.ChangeDriverLicense(driverLicenseChangedEvent.NewDriverLicense);
               }
               else if (@event is UserMedicalCertificateExpirationDateChangedEvent medicalCertificateExpirationDateChangedEvent)
               {
                    driver.ChangeMedicalCertificateExpirationDate(medicalCertificateExpirationDateChangedEvent.NewMedicalCertificateExpirationDate);
               }
               else if (@event is UserDriverLicenseExpirationDateChangedEvent driverLicenseExpirationDateChangedEvent)
               {
                    driver.ChangeDriverLicenseExpirationDate(driverLicenseExpirationDateChangedEvent.NewDriverLicenseExpirationDate);
               }
          }

          private void ApplyEvent(Worker worker, IDomainEvent @event)
          {
               if (@event is UserNameChangedEvent nameChangedEvent)
               {
                    worker.ChangeName(nameChangedEvent.NewName);
               }
               else if (@event is UserPhoneChangedEvent phoneChangedEvent)
               {
                    worker.ChangePhone(phoneChangedEvent.NewPhone);
               }
               else if (@event is UserBirthDateChangedEvent birthDateChangedEvent)
               {
                    worker.ChangeBirthDate(birthDateChangedEvent.NewBirthDate);
               }
               else if (@event is UserPositionChangedEvent positionChangedEvent)
               {
                    worker.ChangePosition(positionChangedEvent.NewPosition);
               }
          }

          private void ApplyEvent(Supplier provider, IDomainEvent @event)
          {
               if (@event is UserNameChangedEvent nameChangedEvent)
               {
                    provider.ChangeName(nameChangedEvent.NewName);
               }
               else if (@event is UserPhoneChangedEvent phoneChangedEvent)
               {
                    provider.ChangePhone(phoneChangedEvent.NewPhone);
               }
               else if (@event is UserBirthDateChangedEvent birthDateChangedEvent)
               {
                    provider.ChangeBirthDate(birthDateChangedEvent.NewBirthDate);
               }
          }

          private void ApplyChanges(Administrator admin, UpdateRecordUserDataRequestDTO request)
          {
               if (!string.IsNullOrEmpty(request.Name))
               {
                    admin.ChangeName(new UserName(request.Name));
                    admin.AddDomainEvent(new UserNameChangedEvent(admin.Id, new UserName(request.Name)));
               }

               if (!string.IsNullOrEmpty(request.Phone))
               {
                    admin.ChangePhone(new UserPhone(request.Phone));
                    admin.AddDomainEvent(new UserPhoneChangedEvent(admin.Id, new UserPhone(request.Phone)));
               }

               if (!string.IsNullOrEmpty(request.BirthDate))
               {
                    admin.ChangeBirthDate(new UserBirthDate(request.BirthDate));
                    admin.AddDomainEvent(new UserBirthDateChangedEvent(admin.Id, new UserBirthDate(request.BirthDate)));
               }
          }

          private void ApplyChanges(Driver driver, UpdateRecordUserDataRequestDTO request)
          {
               if (!string.IsNullOrEmpty(request.Name))
               {
                    driver.ChangeName(new UserName(request.Name));
                    driver.AddDomainEvent(new UserNameChangedEvent(driver.Id, new UserName(request.Name)));
               }

               if (!string.IsNullOrEmpty(request.Phone))
               {
                    driver.ChangePhone(new UserPhone(request.Phone));
                    driver.AddDomainEvent(new UserPhoneChangedEvent(driver.Id, new UserPhone(request.Phone)));
               }

               if (!string.IsNullOrEmpty(request.BirthDate))
               {
                    driver.ChangeBirthDate(new UserBirthDate(request.BirthDate));
                    driver.AddDomainEvent(new UserBirthDateChangedEvent(driver.Id, new UserBirthDate(request.BirthDate)));
               }

               if (!string.IsNullOrEmpty(request.CedulaExpirationDate))
               {
                    driver.ChangeCedulaExpirationDate(new UserCedulaExpirationDate(request.CedulaExpirationDate));
                    driver.AddDomainEvent(new UserCedulaExpirationDateChangedEvent(driver.Id, new UserCedulaExpirationDate(request.CedulaExpirationDate)));
               }

               if (!string.IsNullOrEmpty(request.MedicalCertificate))
               {
                    driver.ChangeMedicalCertificate(new UserMedicalCertificate(request.MedicalCertificate));
                    driver.AddDomainEvent(new UserMedicalCertificateChangedEvent(driver.Id, new UserMedicalCertificate(request.MedicalCertificate)));
               }

               if (!string.IsNullOrEmpty(request.MedicalCertificateExpirationDate))
               {
                    driver.ChangeMedicalCertificateExpirationDate(new UserMedicalCertificateExpirationDate(request.MedicalCertificateExpirationDate));
                    driver.AddDomainEvent(new UserMedicalCertificateExpirationDateChangedEvent(driver.Id, new UserMedicalCertificateExpirationDate(request.MedicalCertificateExpirationDate)));
               }

               if (!string.IsNullOrEmpty(request.DriverLicense))
               {
                    driver.ChangeDriverLicense(new UserDriverLicense(request.DriverLicense));
                    driver.AddDomainEvent(new UserDriverLicenseChangedEvent(driver.Id, new UserDriverLicense(request.DriverLicense)));
               }

               if (!string.IsNullOrEmpty(request.DriverLicenseExpirationDate))
               {
                    driver.ChangeDriverLicenseExpirationDate(new UserDriverLicenseExpirationDate(request.DriverLicenseExpirationDate));
                    driver.AddDomainEvent(new UserDriverLicenseExpirationDateChangedEvent(driver.Id, new UserDriverLicenseExpirationDate(request.DriverLicenseExpirationDate)));
               }
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
          }

          private void ApplyChanges(Supplier provider, UpdateRecordUserDataRequestDTO request)
          {
               if (!string.IsNullOrEmpty(request.Name))
               {
                    provider.ChangeName(new UserName(request.Name));
                    provider.AddDomainEvent(new UserNameChangedEvent(provider.Id, new UserName(request.Name)));
               }

               if (!string.IsNullOrEmpty(request.Phone))
               {
                    provider.ChangePhone(new UserPhone(request.Phone));
                    provider.AddDomainEvent(new UserPhoneChangedEvent(provider.Id, new UserPhone(request.Phone)));
               }

               if (!string.IsNullOrEmpty(request.BirthDate))
               {
                    provider.ChangeBirthDate(new UserBirthDate(request.BirthDate));
                    provider.AddDomainEvent(new UserBirthDateChangedEvent(provider.Id, new UserBirthDate(request.BirthDate)));
               }
          }
     }
}