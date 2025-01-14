namespace API_GruasUCAB.Auth.Application.Decorators
{
     public class RecordUserDataSecurityDecorator<TRequest, TResponse> : IService<TRequest, TResponse>
     {
          private readonly IService<TRequest, TResponse> _innerService;
          private readonly IKeycloakRepository _keycloakRepository;
          private readonly IHttpClientFactory _httpClientFactory;
          private readonly HeadersToken _headersToken;

          public RecordUserDataSecurityDecorator(
              IService<TRequest, TResponse> innerService,
              IKeycloakRepository keycloakRepository,
              IHttpClientFactory httpClientFactory,
              IHttpContextAccessor httpContextAccessor)
          {
               _innerService = innerService ?? throw new ArgumentNullException(nameof(innerService));
               _keycloakRepository = keycloakRepository ?? throw new ArgumentNullException(nameof(keycloakRepository));
               _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
               _headersToken = new HeadersToken(httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor)));
          }

          public async Task<TResponse> Execute(TRequest request)
          {
               var token = _headersToken.GetToken();
               if (string.IsNullOrEmpty(token))
               {
                    throw new UnauthorizedException("Authorization header is missing.");
               }

               var client = _httpClientFactory.CreateClient();
               var (userId, role, email) = await _keycloakRepository.IntrospectTokenAsync(client, token);

               // Escribir en la consola los valores obtenidos del token
               Console.WriteLine($"Token Introspection - UserId: {userId}, Role: {role}, Email: {email}");

               // Escribir en la consola los valores de la solicitud
               Console.WriteLine($"Request - UserEmail: {(request as dynamic)?.UserEmail}, Role: {(request as dynamic)?.Role}, UserId: {(request as dynamic)?.UserId}");

               // Verificar que los campos coincidan con los valores del token
               if (email != (request as dynamic)?.UserEmail || role != (request as dynamic)?.Role || userId != (request as dynamic)?.UserId.ToString())
               {
                    throw new UnauthorizedException("Unauthorized access: token validation failed.");
               }

               return await _innerService.Execute(request);
          }
     }
}