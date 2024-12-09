namespace API_GruasUCAB.Users.Domain.Factories
{
    public interface IUserFactory
    {
        Administrator RecordAdministratorDataEvent(
            UserId id,
            UserName name,
            UserEmail email,
            UserPhone phone,
            UserCedula cedula,
            UserBirthDate birthDate);

        Worker RecordWorkerDataEvent(
            UserId id,
            UserName name,
            UserEmail email,
            UserPhone phone,
            UserCedula cedula,
            UserBirthDate birthDate,
            UserPosition position);

        Supplier RecordSupplierDataEvent(
            UserId id,
            UserName name,
            UserEmail email,
            UserPhone phone,
            UserCedula cedula,
            UserBirthDate birthDate);

        Driver RecordDriverDataEvent(
            UserId id,
            UserName name,
            UserEmail email,
            UserPhone phone,
            UserCedula cedula,
            UserBirthDate birthDate,
            UserCedulaExpirationDate cedulaExpirationDate,
            UserMedicalCertificate medicalCertificate,
            UserMedicalCertificateExpirationDate medicalCertificateExpirationDate,
            UserDriverLicense driverLicense,
            UserDriverLicenseExpirationDate driverLicenseExpirationDate);
    }
}