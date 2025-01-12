using API_GruasUCAB.Auth.Infrastructure.Adapters.HeadersToken;
using Microsoft.AspNetCore.Http;

namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public class RecordUserDataService : IService<RecordUserDataRequestDTO, RecordUserDataResponseDTO>
     {
          private readonly IUserFactory _userFactory;
          private readonly IEventStore _eventStore;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly HeadersToken _headersToken;

          public RecordUserDataService(IUserFactory userFactory, IEventStore eventStore, IKeycloakRepository keycloakRepository, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
          {
               _userFactory = userFactory;
               _eventStore = eventStore;
               _keycloakRepository = keycloakRepository;
               _httpClientFactory = httpClientFactory;
               _headersToken = new HeadersToken(httpContextAccessor);
          }

          public async Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request)
          {
               var token = _headersToken.GetToken();
               var client = _httpClientFactory.CreateClient();
               var (userId, role, email) = await _keycloakRepository.IntrospectTokenAsync(client, token);

               if (email != request.UserEmail || role != request.Role || userId != request.Id.ToString())
               {
                    throw new UnauthorizedException("Unauthorized access: token validation failed.");
               }

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
                         user = _userFactory.RecordAdministratorDataEvent(
                             new UserId(request.Id.ToString()),
                             new UserName(request.Name),
                             new UserEmail(request.UserEmail),
                             new UserPhone(request.Phone),
                             new UserCedula(request.Cedula),
                             new UserBirthDate(request.BirthDate)
                         );

                         var domainEvent = new RecordAdministratorDataEvent(
                             new UserId(request.Id.ToString()),
                             new UserName(request.Name),
                             new UserEmail(request.UserEmail),
                             new UserPhone(request.Phone),
                             new UserBirthDate(request.BirthDate)
                         );
                         domainEvents.Add(domainEvent);
                    }
                    else if (userRole == UserRole.Conductor)
                    {
                         user = _userFactory.RecordDriverDataEvent(
                             new UserId(request.Id.ToString()),
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
                             new UserId(request.Id.ToString()),
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
                         user = _userFactory.RecordWorkerDataEvent(
                             new UserId(request.Id.ToString()),
                             new UserName(request.Name),
                             new UserEmail(request.UserEmail),
                             new UserPhone(request.Phone),
                             new UserCedula(request.Cedula),
                             new UserBirthDate(request.BirthDate),
                             new UserPosition(request.Position ?? throw new ArgumentNullException(nameof(request.Position)))
                         );

                         var domainEvent = new RecordWorkerDataEvent(
                             new UserId(request.Id.ToString()),
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
                         user = _userFactory.RecordSupplierDataEvent(
                             new UserId(request.Id.ToString()),
                             new UserName(request.Name),
                             new UserEmail(request.UserEmail),
                             new UserPhone(request.Phone),
                             new UserCedula(request.Cedula),
                             new UserBirthDate(request.BirthDate)
                         );

                         var domainEvent = new RecordSupplierDataEvent(
                             new UserId(request.Id.ToString()),
                             new UserName(request.Name),
                             new UserEmail(request.UserEmail),
                             new UserPhone(request.Phone),
                             new UserBirthDate(request.BirthDate)
                         );
                         domainEvents.Add(domainEvent);
                    }

                    // Registra los eventos en el EventStore
                    await _eventStore.AppendEvents(request.Id.ToString(), domainEvents);
                    //await _userRepository.AddAsync(user);

                    return new RecordUserDataResponseDTO
                    {
                         Success = true,
                         Message = $"{userRole} created successfully",
                         UserEmail = request.UserEmail,
                         UserId = request.Id
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