namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public class RecordUserDataService : IService<RecordUserDataRequestDTO, RecordUserDataResponseDTO>
     {
          private readonly IRecordAdministratorData _recordAdministratorData;
          private readonly IRecordDriverData _recordDriverData;
          private readonly IRecordWorkerData _recordWorkerData;
          private readonly IRecordProviderData _recordProviderData;

          public RecordUserDataService(
              IRecordAdministratorData recordAdministratorData,
              IRecordDriverData recordDriverData,
              IRecordWorkerData recordWorkerData,
              IRecordProviderData recordProviderData)
          {
               _recordAdministratorData = recordAdministratorData;
               _recordDriverData = recordDriverData;
               _recordWorkerData = recordWorkerData;
               _recordProviderData = recordProviderData;
          }

          public async Task<RecordUserDataResponseDTO> Execute(RecordUserDataRequestDTO request)
          {
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
                         return await _recordAdministratorData.Execute(request);
                    }
                    else if (userRole == UserRole.Conductor)
                    {
                         return await _recordDriverData.Execute(request);
                    }
                    else if (userRole == UserRole.Trabajador)
                    {
                         return await _recordWorkerData.Execute(request);
                    }
                    else if (userRole == UserRole.Proveedor)
                    {
                         return await _recordProviderData.Execute(request);
                    }
                    else
                    {
                         throw new InvalidOperationException("Invalid user role");
                    }
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