namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public class UpdateRecordUserDataService : IService<UpdateRecordUserDataRequestDTO, UpdateRecordUserDataResponseDTO>
     {
          private readonly IUpdateRecordUserData _updateRecordAdministratorData;
          private readonly IUpdateRecordUserData _updateRecordDriverData;
          private readonly IUpdateRecordUserData _updateRecordWorkerData;
          private readonly IUpdateRecordUserData _updateRecordSupplierData;

          public UpdateRecordUserDataService(
              IUpdateRecordUserData updateRecordAdministratorData,
              IUpdateRecordUserData updateRecordDriverData,
              IUpdateRecordUserData updateRecordWorkerData,
              IUpdateRecordUserData updateRecordSupplierData)
          {
               _updateRecordAdministratorData = updateRecordAdministratorData;
               _updateRecordDriverData = updateRecordDriverData;
               _updateRecordWorkerData = updateRecordWorkerData;
               _updateRecordSupplierData = updateRecordSupplierData;
          }

          public async Task<UpdateRecordUserDataResponseDTO> Execute(UpdateRecordUserDataRequestDTO request)
          {
               if (!Enum.TryParse(request.Role, out UserRole userRole))
               {
                    return await Task.FromResult(new UpdateRecordUserDataResponseDTO
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
                              return await _updateRecordAdministratorData.Execute(request);
                         case UserRole.Conductor:
                              return await _updateRecordDriverData.Execute(request);
                         case UserRole.Trabajador:
                              return await _updateRecordWorkerData.Execute(request);
                         case UserRole.Proveedor:
                              return await _updateRecordSupplierData.Execute(request);
                         default:
                              throw new InvalidOperationException("Invalid user role");
                    }
               }
               catch (Exception ex)
               {
                    return await Task.FromResult(new UpdateRecordUserDataResponseDTO
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