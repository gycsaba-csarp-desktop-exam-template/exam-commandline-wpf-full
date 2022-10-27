using Kreta.Models.AbstractClass;
using Kreta.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServiceKretaLogger;

namespace KretaWebApi.ActionFilters
{
    public class ValidateEntityExistsAttribute<T> : IActionFilter where T : ClassWithId
    {
        private KretaContext kretaContext;
        ILoggerManager loggerManager;

        public ValidateEntityExistsAttribute(ILoggerManager loggerManager, KretaContext context)
        {
            this.kretaContext = context;
            this.loggerManager = loggerManager;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            long id = -1;
            loggerManager.LogInfo($"API kérés esetén a kontexusban kévő kulcsok: {context.ActionArguments.Keys}");
            if (context.ActionArguments.ContainsKey("Id"))
            {
                try
                {
                    loggerManager.LogInfo($"API kérés esetén az azonosított id: {context.ActionArguments["Id"]}");
                    //id = (long)context.ActionArguments["Id"];
                    id = Convert.ToInt64(context.ActionArguments["Id"]);
                }
                catch (Exception e)
                {
                    loggerManager.LogError(e.Message);
                    context.Result = new BadRequestObjectResult("The id paramter is not valid type");
                }               
            }
            else
            {
                loggerManager.LogError("API kérés esetén a válaszban kapott adatnak nincs id-je");
                context.Result = new BadRequestObjectResult("The id parameter is bad.");
                return;
            }
            var entity = kretaContext.Set<T>().SingleOrDefault(entity => entity.Id.Equals(id));
            if (entity == null)
            {
                loggerManager.LogError($"API kérés esetén {id} azonosítójú elem nem létezik.");
                context.Result = new NotFoundResult();
            }
            else
            {
                loggerManager.LogInfo($"API kérés esetén {id} azonosítójú elem lekérése sikerült.");
                context.HttpContext.Items.Add("entity", entity);
            }
                
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
