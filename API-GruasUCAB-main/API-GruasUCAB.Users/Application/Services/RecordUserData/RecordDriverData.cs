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
               if (request.CedulaExpirationDate == null)
                    throw new ArgumentNullException(nameof(request.CedulaExpirationDate));
               if (request.MedicalCertificate == null)
                    throw new ArgumentNullException(nameof(request.MedicalCertificate));
               if (request.MedicalCertificateExpirationDate == null)
                    throw new ArgumentNullException(nameof(request.MedicalCertificateExpirationDate));
               if (request.DriverLicense == null)
                    throw new ArgumentNullException(nameof(request.DriverLicense));
               if (request.DriverLicenseExpirationDate == null)
                    throw new ArgumentNullException(nameof(request.DriverLicenseExpirationDate));

               var driver = _driverFactory.CreateDriver(
                   new UserId(request.UserId.ToString()),
                   new UserName(request.Name),
                   new UserEmail(request.UserEmail),
                   new UserPhone(request.Phone),
                   new UserCedula(request.Cedula),
                   new UserBirthDate(request.BirthDate),
                   new UserCedulaExpirationDate(request.CedulaExpirationDate),
                   new UserMedicalCertificate(request.MedicalCertificate),
                   new UserMedicalCertificateExpirationDate(request.MedicalCertificateExpirationDate),
                   new UserDriverLicense(request.DriverLicense),
                   new UserDriverLicenseExpirationDate(request.DriverLicenseExpirationDate)
               );

               var driverDTO = new DriverDTO
               {
                    Id = request.UserId,
                    Name = request.Name,
                    UserEmail = request.UserEmail,
                    Phone = request.Phone,
                    Cedula = request.Cedula,
                    BirthDate = request.BirthDate,
                    CedulaExpirationDate = request.CedulaExpirationDate,
                    MedicalCertificate = request.MedicalCertificate,
                    MedicalCertificateExpirationDate = request.MedicalCertificateExpirationDate,
                    DriverLicense = request.DriverLicense,
                    DriverLicenseExpirationDate = request.DriverLicenseExpirationDate
               };

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