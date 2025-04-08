using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace TodoApi.Controllers.ExceptionFilters;

public class CustomExceptionFilterTest : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var response = new
        {
            Message = "An error occurred while processing your request.",
            Details = context.Exception.Message
        };

        context.Result = new ObjectResult(response)
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}
