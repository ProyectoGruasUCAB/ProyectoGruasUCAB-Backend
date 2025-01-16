namespace API_GruasUCAB.Users.Application.Services.UpdateUser
{
     public class UpdateRecordUserDataService : IService<UpdateRecordUserDataRequestDTO, UpdateRecordUserDataResponseDTO>
     {
          private readonly IUpdateRecordAdministratorData _updateRecordAdministratorData;
          private readonly IUpdateRecordDriverData _updateRecordDriverData;
          private readonly IUpdateRecordWorkerData _updateRecordWorkerData;
          private readonly IUpdateRecordSupplierData _updateRecordSupplierData;

          public UpdateRecordUserDataService(
              IUpdateRecordAdministratorData updateRecordAdministratorData,
              IUpdateRecordDriverData updateRecordDriverData,
              IUpdateRecordWorkerData updateRecordWorkerData,
              IUpdateRecordSupplierData updateRecordSupplierData)
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
                    if (userRole == UserRole.Administrador)
                    {
                         return await _updateRecordAdministratorData.Execute(request);
                    }
                    else if (userRole == UserRole.Conductor)
                    {
                         return await _updateRecordDriverData.Execute(request);
                    }
                    else if (userRole == UserRole.Trabajador)
                    {
                         return await _updateRecordWorkerData.Execute(request);
                    }
                    else if (userRole == UserRole.Proveedor)
                    {
                         return await _updateRecordSupplierData.Execute(request);
                    }
                    else
                    {
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