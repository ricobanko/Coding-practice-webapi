namespace TodoApi.Middleware;

public class RequestMiddlewareTest
{
    private readonly RequestDelegate _next;

    public RequestMiddlewareTest(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) 
    {
        var Id = context.Request.RouteValues["id"]?.ToString();

        if (!string.IsNullOrWhiteSpace(Id))
        {
            Console.WriteLine(Id);
        }

        await _next(context);
    }
}

public static class RequestMiddlewareTestExtension 
{
    public static IApplicationBuilder UseRequestMiddlewareTest(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestMiddlewareTest>();
    }
}
