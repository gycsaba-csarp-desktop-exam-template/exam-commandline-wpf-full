using Kreta.Models.Context;
using KretaParancssoriAlkalmazas.Models.AbstractClass;
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
            if (context.ActionArguments.ContainsKey("Id"))
            {
                id = (long) context.ActionArguments["Id"];
            }
            else
            {
                loggerManager.LogError("API Kérés esetén a válaszban kapott adatnak nincs id-je");
                context.Result = new BadRequestObjectResult("The id parameter is bad.");
                return;
            }
            var entity = kretaContext.Set<T>().SingleOrDefault(entity => entity.Id.Equals(id));
            if (entity == null)
            {
                loggerManager.LogError($"API Kérés esetén {id} azonosítójú elem nem létezik.");
                context.Result = new NotFoundResult();
            }
            else
            {
                loggerManager.LogError($"API Kérés esetén {id} azonosítójú elem lekérése sikerült.");
                context.HttpContext.Items.Add("entity", entity);
            }
                
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
