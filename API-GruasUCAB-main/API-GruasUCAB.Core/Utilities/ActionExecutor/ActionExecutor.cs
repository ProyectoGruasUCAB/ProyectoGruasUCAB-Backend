namespace API_GruasUCAB.Core.Utilities.ActionExecutor
{
     public static class ActionExecutor
     {
          public static async Task<IActionResult> Execute(Func<Task<IActionResult>> action, ModelStateDictionary modelState, Microsoft.Extensions.Logging.ILogger logger, string actionName)
          {
               if (!modelState.IsValid)
               {
                    var errors = new List<string>();
                    foreach (var modelStateValue in modelState.Values)
                    {
                         foreach (var error in modelStateValue.Errors)
                         {
                              errors.Add(error.ErrorMessage);
                         }
                    }
                    logger.LogWarning("Model state is invalid for action {ActionName}. Errors: {Errors}", actionName, errors);
                    return new BadRequestObjectResult(new { Errors = errors });
               }
               try
               {
                    logger.LogInformation("Executing action {ActionName}", actionName);

                    var result = await action();

                    if (result is ObjectResult objectResult)
                    {
                         var outputJson = JsonConvert.SerializeObject(objectResult.Value, new JsonSerializerSettings
                         {
                              ContractResolver = new DefaultContractResolver
                              {
                                   IgnoreSerializableAttribute = true
                              },
                              ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                         });
                         logger.LogInformation("Action {ActionName} executed successfully with output: {Output}", actionName, outputJson);
                    }
                    else
                    {
                         logger.LogInformation("Action {ActionName} executed successfully", actionName);
                    }

                    return result;
               }
               catch (UnauthorizedException ex)
               {
                    logger.LogWarning("UnauthorizedException in action {ActionName}: {Message}", actionName, ex.Message);
                    return new UnauthorizedObjectResult(new { ex.Message, ex.Errors });
               }
               catch (Exception ex)
               {
                    logger.LogError("Exception in action {ActionName}: {Message}", actionName, ex.Message);
                    return new ObjectResult($"Error interno del servidor: {ex.Message}") { StatusCode = 500 };
               }
          }
     }
}