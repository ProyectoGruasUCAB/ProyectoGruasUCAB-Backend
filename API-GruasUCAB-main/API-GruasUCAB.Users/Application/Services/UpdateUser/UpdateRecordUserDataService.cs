namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public class UpdateRecordUserDataService : IService<UpdateRecordUserDataRequestDTO, UpdateRecordUserDataResponseDTO>
     {
          private readonly IEventStore _eventStore;
          private readonly IAdministratorFactory _administratorFactory;
          private readonly IDriverFactory _driverFactory;
          private readonly IWorkerFactory _workerFactory;
          private readonly ISupplierFactory _supplierFactory;

          public UpdateRecordUserDataService(
              IEventStore eventStore,
              IAdministratorFactory administratorFactory,
              IDriverFactory driverFactory,
              IWorkerFactory workerFactory,
              ISupplierFactory supplierFactory)
          {
               _eventStore = eventStore;
               _administratorFactory = administratorFactory;
               _driverFactory = driverFactory;
               _workerFactory = workerFactory;
               _supplierFactory = supplierFactory;
          }

          public async Task<UpdateRecordUserDataResponseDTO> Execute(UpdateRecordUserDataRequestDTO request)
          {
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

                    switch (userRole)
                    {
                         case UserRole.Administrador:
                              user = await _administratorFactory.GetAdministratorById(new UserId(request.UserId.ToString()));
                              ApplyChanges((Administrator)user, request);
                              break;
                         case UserRole.Conductor:
                              user = await _driverFactory.GetDriverById(new UserId(request.UserId.ToString()));
                              ApplyChanges((Driver)user, request);
                              break;
                         case UserRole.Trabajador:
                              user = await _workerFactory.GetWorkerById(new UserId(request.UserId.ToString()));
                              ApplyChanges((Worker)user, request);
                              break;
                         case UserRole.Proveedor:
                              user = await _supplierFactory.GetSupplierById(new UserId(request.UserId.ToString()));
                              ApplyChanges((Supplier)user, request);
                              break;
                         default:
                              throw new InvalidOperationException("Invalid user role");
                    }

                    var newEvents = user?.PullEvents() ?? throw new InvalidOperationException("User events could not be pulled.");
                    await _eventStore.AppendEvents(request.UserId.ToString(), newEvents);

                    var userDetails = GetUserDetails(user);
                    return new UpdateRecordUserDataResponseDTO
                    {
                         Success = true,
                         Message = $"User updated successfully. {userDetails}",
                         UserEmail = request.UserEmail,
                         UserId = request.UserId
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
     }
}