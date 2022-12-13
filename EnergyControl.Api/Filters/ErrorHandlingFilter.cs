using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Net;

namespace EnergyControl.Api.Filters
{
    public class ErrorHandlingFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Debug.WriteLine(context.Exception);
            var details = new ProblemDetails
            {
                Title = "Something went wrong.",
                Status = (int)HttpStatusCode.InternalServerError
            };
            context.Result = new ObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}
