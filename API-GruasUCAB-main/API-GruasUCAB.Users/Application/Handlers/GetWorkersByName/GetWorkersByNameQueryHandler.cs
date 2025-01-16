namespace API_GruasUCAB.Users.Application.Handlers.GetWorkersByName
{
     public class GetWorkersByNameQueryHandler : IRequestHandler<GetWorkersByNameQuery, GetWorkersByNameResponseDTO>
     {
          private readonly IWorkerRepository _workerRepository;

          public GetWorkersByNameQueryHandler(IWorkerRepository workerRepository)
          {
               _workerRepository = workerRepository;
          }

          public async Task<GetWorkersByNameResponseDTO> Handle(GetWorkersByNameQuery request, CancellationToken cancellationToken)
          {
               var workers = await _workerRepository.GetWorkersByNameAsync(request.Name);
               return new GetWorkersByNameResponseDTO { Workers = workers };
          }
     }
}