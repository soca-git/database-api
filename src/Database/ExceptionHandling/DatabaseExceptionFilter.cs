using Database.Core.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Database.ExceptionHandling
{
    public class DatabaseExceptionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // do nothing...
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is DatabaseException exception)
            {
                context.Result = new ObjectResult(exception.Payload)
                {
                    StatusCode = (int) exception.Payload.StatusCode
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
