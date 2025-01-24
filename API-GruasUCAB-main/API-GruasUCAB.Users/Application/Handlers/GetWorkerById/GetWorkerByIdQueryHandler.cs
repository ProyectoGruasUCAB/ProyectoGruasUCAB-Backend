namespace API_GruasUCAB.Users.Application.Handlers.GetWorkerById
{
     public class GetWorkerByIdQueryHandler : IRequestHandler<GetWorkerByIdQuery, GetWorkerByIdResponseDTO>
     {
          private readonly IWorkerRepository _workerRepository;

          public GetWorkerByIdQueryHandler(IWorkerRepository workerRepository)
          {
               _workerRepository = workerRepository;
          }

          public async Task<GetWorkerByIdResponseDTO> Handle(GetWorkerByIdQuery request, CancellationToken cancellationToken)
          {
               var worker = await _workerRepository.GetWorkerByIdAsync(request.WorkerId);
               return new GetWorkerByIdResponseDTO { Worker = worker };
          }
     }
}