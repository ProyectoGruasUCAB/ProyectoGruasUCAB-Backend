namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public class RecordDriverData : IRecordDriverData
     {
          private readonly IDriverFactory _driverFactory;
          private readonly IDriverRepository _driverRepository;

          public RecordDriverData(IDriverFactory driverFactory, IDriverRepository driverRepository)
          {
               _driverFactory = driverFactory;
               _driverRepository = driverRepository;
          }

          public async Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request)
          {
               if (request.MedicalCertificate == null)
                    throw new ArgumentNullException(nameof(request.MedicalCertificate));
               if (request.MedicalCertificateExpirationDate == null)
                    throw new ArgumentNullException(nameof(request.MedicalCertificateExpirationDate));
               if (request.DriverLicense == null)
                    throw new ArgumentNullException(nameof(request.DriverLicense));
               if (request.DriverLicenseExpirationDate == null)
                    throw new ArgumentNullException(nameof(request.DriverLicenseExpirationDate));
               if (!request.WorkplaceId.HasValue)
                    throw new ArgumentNullException(nameof(request.WorkplaceId), "WorkplaceId is required for drivers.");

               var driver = _driverFactory.CreateDriver(
                   new UserId(request.UserId),
                   new UserName(request.Name),
                   new UserEmail(request.UserEmail),
                   new UserPhone(request.Phone),
                   new UserCedula(request.Cedula),
                   new UserBirthDate(request.BirthDate),
                   new UserMedicalCertificate(request.MedicalCertificate),
                   new UserMedicalCertificateExpirationDate(request.MedicalCertificateExpirationDate),
                   new UserDriverLicense(request.DriverLicense),
                   new UserDriverLicenseExpirationDate(request.DriverLicenseExpirationDate),
                   new SupplierId(request.WorkplaceId.Value)
               );

               var driverDTO = driver.ToDTO();
               await _driverRepository.AddDriverAsync(driverDTO);

               return new RecordUserDataResponseDTO
               {
                    Success = true,
                    Message = "Driver created successfully",
                    UserEmail = request.UserEmail,
                    UserId = request.UserId
               };
          }
     }
}