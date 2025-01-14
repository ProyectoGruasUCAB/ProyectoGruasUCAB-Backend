namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public class RecordUserDataService : IService<RecordUserDataRequestDTO, RecordUserDataResponseDTO>
     {
          private readonly IAdministratorFactory _administratorFactory;
          private readonly IDriverFactory _driverFactory;
          private readonly IWorkerFactory _workerFactory;
          private readonly ISupplierFactory _supplierFactory;
          private readonly IEventStore _eventStore;

          public RecordUserDataService(
              IAdministratorFactory administratorFactory,
              IDriverFactory driverFactory,
              IWorkerFactory workerFactory,
              ISupplierFactory supplierFactory,
              IEventStore eventStore)
          {
               _administratorFactory = administratorFactory;
               _driverFactory = driverFactory;
               _workerFactory = workerFactory;
               _supplierFactory = supplierFactory;
               _eventStore = eventStore;
          }

          public async Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request)
          {
               object user;
               List<IDomainEvent> domainEvents = new List<IDomainEvent>();

               if (!Enum.TryParse(request.Role, out UserRole userRole))
               {
                    return await Task.FromResult(new RecordUserDataResponseDTO
                    {
                         Success = false,
                         Message = "Invalid user role",
                         UserEmail = request.UserEmail,
                         UserId = Guid.Empty
                    });
               }

               try
               {
                    if (userRole == UserRole.Administrador)
                    {
                         user = _administratorFactory.CreateAdministrator(
                             new UserId(request.UserId.ToString()),
                             new UserName(request.Name),
                             new UserEmail(request.UserEmail),
                             new UserPhone(request.Phone),
                             new UserCedula(request.Cedula),
                             new UserBirthDate(request.BirthDate)
                         );

                         var domainEvent = new RecordAdministratorDataEvent(
                             new UserId(request.UserId.ToString()),
                             new UserName(request.Name),
                             new UserEmail(request.UserEmail),
                             new UserPhone(request.Phone),
                             new UserBirthDate(request.BirthDate)
                         );
                         domainEvents.Add(domainEvent);
                    }
                    else if (userRole == UserRole.Conductor)
                    {
                         user = _driverFactory.CreateDriver(
                             new UserId(request.UserId.ToString()),
                             new UserName(request.Name),
                             new UserEmail(request.UserEmail),
                             new UserPhone(request.Phone),
                             new UserCedula(request.Cedula),
                             new UserBirthDate(request.BirthDate),
                             new UserCedulaExpirationDate(request.CedulaExpirationDate ?? throw new ArgumentNullException(nameof(request.CedulaExpirationDate))),
                             new UserMedicalCertificate(request.MedicalCertificate ?? throw new ArgumentNullException(nameof(request.MedicalCertificate))),
                             new UserMedicalCertificateExpirationDate(request.MedicalCertificateExpirationDate ?? throw new ArgumentNullException(nameof(request.MedicalCertificateExpirationDate))),
                             new UserDriverLicense(request.DriverLicense ?? throw new ArgumentNullException(nameof(request.DriverLicense))),
                             new UserDriverLicenseExpirationDate(request.DriverLicenseExpirationDate ?? throw new ArgumentNullException(nameof(request.DriverLicenseExpirationDate)))
                         );

                         var domainEvent = new RecordDriverDataEvent(
                             new UserId(request.UserId.ToString()),
                             new UserName(request.Name),
                             new UserEmail(request.UserEmail),
                             new UserPhone(request.Phone),
                             new UserBirthDate(request.BirthDate),
                             new UserCedulaExpirationDate(request.CedulaExpirationDate),
                             new UserMedicalCertificate(request.MedicalCertificate),
                             new UserMedicalCertificateExpirationDate(request.MedicalCertificateExpirationDate),
                             new UserDriverLicense(request.DriverLicense),
                             new UserDriverLicenseExpirationDate(request.DriverLicenseExpirationDate)
                         );
                         domainEvents.Add(domainEvent);
                    }
                    else if (userRole == UserRole.Trabajador)
                    {
                         user = _workerFactory.CreateWorker(
                             new UserId(request.UserId.ToString()),
                             new UserName(request.Name),
                             new UserEmail(request.UserEmail),
                             new UserPhone(request.Phone),
                             new UserCedula(request.Cedula),
                             new UserBirthDate(request.BirthDate),
                             new UserPosition(request.Position ?? throw new ArgumentNullException(nameof(request.Position)))
                         );

                         var domainEvent = new RecordWorkerDataEvent(
                             new UserId(request.UserId.ToString()),
                             new UserName(request.Name),
                             new UserEmail(request.UserEmail),
                             new UserPhone(request.Phone),
                             new UserBirthDate(request.BirthDate),
                             new UserPosition(request.Position)
                         );
                         domainEvents.Add(domainEvent);
                    }
                    else if (userRole == UserRole.Proveedor)
                    {
                         user = _supplierFactory.CreateSupplier(
                             new UserId(request.UserId.ToString()),
                             new UserName(request.Name),
                             new UserEmail(request.UserEmail),
                             new UserPhone(request.Phone),
                             new UserCedula(request.Cedula),
                             new UserBirthDate(request.BirthDate)
                         );

                         var domainEvent = new RecordSupplierDataEvent(
                             new UserId(request.UserId.ToString()),
                             new UserName(request.Name),
                             new UserEmail(request.UserEmail),
                             new UserPhone(request.Phone),
                             new UserBirthDate(request.BirthDate)
                         );
                         domainEvents.Add(domainEvent);
                    }

                    // Registra los eventos en el EventStore
                    await _eventStore.AppendEvents(request.UserId.ToString(), domainEvents);

                    return new RecordUserDataResponseDTO
                    {
                         Success = true,
                         Message = $"{userRole} created successfully",
                         UserEmail = request.UserEmail,
                         UserId = request.UserId
                    };
               }
               catch (Exception ex)
               {
                    return await Task.FromResult(new RecordUserDataResponseDTO
                    {
                         Success = false,
                         Message = ex.Message,
                         UserEmail = request.UserEmail,
                         UserId = Guid.Empty
                    });
               }
          }
     }
}