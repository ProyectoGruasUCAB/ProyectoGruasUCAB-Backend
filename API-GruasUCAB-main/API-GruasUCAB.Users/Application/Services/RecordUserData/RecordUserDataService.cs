namespace API_GruasUCAB.Users.Application.Services.RecordUserData
{
     public class RecordUserDataService : IService<RecordUserDataRequestDTO, RecordUserDataResponseDTO>
     {
          private readonly IRecordUserData _recordAdministratorData;
          private readonly IRecordUserData _recordDriverData;
          private readonly IRecordUserData _recordWorkerData;
          private readonly IRecordUserData _recordSupplierData;

          public RecordUserDataService(
              IRecordUserData recordAdministratorData,
              IRecordUserData recordDriverData,
              IRecordUserData recordWorkerData,
              IRecordUserData recordSupplierData)
          {
               _recordAdministratorData = recordAdministratorData;
               _recordDriverData = recordDriverData;
               _recordWorkerData = recordWorkerData;
               _recordSupplierData = recordSupplierData;
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
                    switch (userRole)
                    {
                         case UserRole.Administrador:
                              return await _recordAdministratorData.Execute(request);
                         case UserRole.Conductor:
                              return await _recordDriverData.Execute(request);
                         case UserRole.Trabajador:
                              return await _recordWorkerData.Execute(request);
                         case UserRole.Proveedor:
                              return await _recordSupplierData.Execute(request);
                         default:
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