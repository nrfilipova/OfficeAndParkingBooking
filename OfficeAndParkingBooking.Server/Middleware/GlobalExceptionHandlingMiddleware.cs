namespace OfficeAndParkingBooking.Server.Middleware
{
    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    using System.Text.Json;

    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails details = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Title = "Server error",
                    Detail = ""
                };

                var json = JsonSerializer.Serialize(details);

                await context.Response.WriteAsync(json);

                context.Response.ContentType = "application/json";
            }
        }
    }
}
