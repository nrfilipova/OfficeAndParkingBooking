namespace OfficeAndParkingBooking.Server.Middleware
{
    using Services.Common.Exceptions;

    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.ComponentModel.DataAnnotations;
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
                var statusCode = ex switch
                {
                    BookingTwiceException => StatusCodes.Status400BadRequest,
                    InvalidOperationException => StatusCodes.Status400BadRequest,
                    CapacityExceededException => StatusCodes.Status400BadRequest,
                    ParkingSpotNotAvailableException => StatusCodes.Status400BadRequest,
                    ValidationException => StatusCodes.Status400BadRequest,
                    UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError
                };

                _logger.LogError(ex, "An error occurred: {Message}", ex.Message);

                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";

                ProblemDetails details = new()
                {
                    Status = statusCode,
                    Detail = ex.Message,
                };

                var json = JsonSerializer.Serialize(details);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
