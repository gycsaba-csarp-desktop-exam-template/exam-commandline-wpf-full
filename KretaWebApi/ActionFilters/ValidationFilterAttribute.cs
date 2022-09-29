using KretaWebApi.ExceptionHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace KretaWebApi.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        //https://code-maze.com/action-filters-aspnetcore/
        //https://stackoverflow.com/questions/72255726/how-to-register-action-filter-in-net-6
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //var param = context.ActionArguments.SingleOrDefault(p => p.Value is IEntity);
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is Object);
            if (param.Value is null)
             {
                context.Result=new BadRequestObjectResult("Object is null");
                return;
            }
            if (!context.ModelState.IsValid)
            {
                var errorInModelState = context.ModelState
                    .Where(error => error.Value.Errors.Count > 0)
                    .ToDictionary(error => error.Key, error => error.Value.Errors.Select(errormessage => errormessage.ErrorMessage)).ToArray();
                
                List<APIModelError> errors = new List<APIModelError>();
                foreach(var error in errorInModelState)
                {
                    foreach(var subError in error.Value)
                    {
                        var errorModel = new APIModelError(error.Key, subError);   
                        errors.Add(errorModel);
                    }
                }
                context.Result = new BadRequestObjectResult(JsonConvert.SerializeObject(errors));
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
