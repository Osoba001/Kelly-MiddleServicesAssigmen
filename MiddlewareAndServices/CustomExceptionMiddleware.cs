using System.Net;

namespace MiddlewareAndServices
{
    public class CustomExceptionMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public CustomExceptionMiddleware(ILogger<CustomExceptionMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ArgumentException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync($" { ex.Message}");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync($"Something went wrong: { ex.Message}");
                _logger.LogError($"Something went wrong: {ex} ");
            }
        }
    }
}
