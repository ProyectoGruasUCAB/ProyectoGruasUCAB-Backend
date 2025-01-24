namespace API_GruasUCAB.Users.Application.Handlers.GetAllWorkers
{
     public class GetAllWorkersQueryHandler : IRequestHandler<GetAllWorkersQuery, GetAllWorkersResponseDTO>
     {
          private readonly IWorkerRepository _workerRepository;

          public GetAllWorkersQueryHandler(IWorkerRepository workerRepository)
          {
               _workerRepository = workerRepository;
          }

          public async Task<GetAllWorkersResponseDTO> Handle(GetAllWorkersQuery request, CancellationToken cancellationToken)
          {
               var workers = await _workerRepository.GetAllWorkersAsync();
               return new GetAllWorkersResponseDTO { Workers = workers };
          }
     }
}