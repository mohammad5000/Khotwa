using Domain.ErrorModel;
using Domain.Exceptions;

namespace API.Middleware;

public class ExceptionMiddleware(RequestDelegate _next, ILogger<ExceptionMiddleware> _logger, IHostEnvironment _env)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            var errorDetail = _env.IsDevelopment()
                ? new ErrorDetail(ex.Message, context.Response.StatusCode, ex.StackTrace)
                : new ErrorDetail(ex.Message, context.Response.StatusCode, "Internal Server Error");
            await context.Response.WriteAsJsonAsync(errorDetail);
        }
    }
}