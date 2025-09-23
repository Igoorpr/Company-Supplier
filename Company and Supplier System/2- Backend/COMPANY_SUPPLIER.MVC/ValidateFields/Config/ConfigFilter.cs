using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace COMPANY_SUPPLIER.MVC.ValidateFields.Config
{
    public class ConfigFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            object result = null;
            foreach (var key in context.ActionArguments.Keys)
            {
                var critique = Dictionary.ValidationDictionary[key];
                if (critique != null)
                {
                    result = critique.Invoke(context.ActionArguments[key]);
                    break;
                }
            }
            if (result != null)
            {
                context.Result = (IActionResult)result;
                return;
            }
            await next();
        }

    }
}
