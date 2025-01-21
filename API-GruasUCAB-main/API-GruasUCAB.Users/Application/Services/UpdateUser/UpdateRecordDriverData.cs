namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public class UpdateRecordDriverData : IUpdateRecordDriverData
     {
          private readonly IDriverFactory _driverFactory;
          private readonly IDriverRepository _driverRepository;

          public UpdateRecordDriverData(IDriverFactory driverFactory, IDriverRepository driverRepository)
          {
               _driverFactory = driverFactory;
               _driverRepository = driverRepository;
          }

          public async Task<UpdateRecordUserDataResponseDTO> Execute(UpdateRecordUserDataRequestDTO request)
          {
               var driver = await _driverFactory.GetDriverById(new UserId(request.UserId.ToString()));
               ApplyChanges(driver, request);
               await _driverRepository.UpdateDriverAsync(driver.ToDTO());

               return new UpdateRecordUserDataResponseDTO
               {
                    Success = true,
                    Message = "Driver updated successfully",
                    UserEmail = request.UserEmail,
                    UserId = request.UserId
               };
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

               if (request.WorkplaceId.HasValue)
               {
                    driver.ChangeSupplierId(new SupplierId(request.WorkplaceId.Value));
                    driver.AddDomainEvent(new SupplierIdChangedEvent(driver.Id, new SupplierId(request.WorkplaceId.Value)));
               }

               if (!string.IsNullOrEmpty(request.Token))
               {
                    driver.ChangeToken(new UserToken(request.Token));
                    driver.AddDomainEvent(new UserTokenChangedEvent(driver.Id, new UserToken(request.Token)));
               }
          }
     }
}