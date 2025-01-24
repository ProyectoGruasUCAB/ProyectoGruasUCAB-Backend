namespace API_GruasUCAB.Users.Application.Handlers.GetWorkersByPosition
{
     public class GetWorkersByPositionQueryHandler : IRequestHandler<GetWorkersByPositionQuery, GetWorkersByPositionResponseDTO>
     {
          private readonly IWorkerRepository _workerRepository;

          public GetWorkersByPositionQueryHandler(IWorkerRepository workerRepository)
          {
               _workerRepository = workerRepository;
          }

          public async Task<GetWorkersByPositionResponseDTO> Handle(GetWorkersByPositionQuery request, CancellationToken cancellationToken)
          {
               var workers = await _workerRepository.GetWorkersByPositionAsync(request.Position);
               return new GetWorkersByPositionResponseDTO { Workers = workers };
          }
     }
}