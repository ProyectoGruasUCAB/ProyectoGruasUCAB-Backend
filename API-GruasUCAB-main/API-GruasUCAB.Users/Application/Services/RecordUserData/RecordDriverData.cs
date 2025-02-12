namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public class RecordDriverData : IRecordDriverData
     {
          private readonly IDriverFactory _driverFactory;
          private readonly IDriverRepository _driverRepository;
          private readonly ISupplierRepository _supplierRepository;
          private readonly INewDriverRepository _newDriverRepository;

          public RecordDriverData(IDriverFactory driverFactory, IDriverRepository driverRepository, ISupplierRepository supplierRepository, INewDriverRepository newDriverRepository)
          {
               _driverFactory = driverFactory;
               _driverRepository = driverRepository;
               _supplierRepository = supplierRepository;
               _newDriverRepository = newDriverRepository;
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

               var supplierId = await _newDriverRepository.GetSupplierIdByUserId(request.UserId);
               var supplier = await _supplierRepository.GetSupplierByIdAsync(supplierId);
               if (supplier == null)
               {
                    return new RecordUserDataResponseDTO
                    {
                         Success = false,
                         Message = "Supplier does not exist",
                         UserEmail = request.UserEmail,
                         UserId = request.UserId
                    };
               }

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
                   new SupplierId(supplierId),
                   request.Token ?? string.Empty
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