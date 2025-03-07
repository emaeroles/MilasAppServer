using API.Response;
using FluentValidation;
using Serilog;
using System.Net;
using System.Text.Json;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public ExceptionMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandleValidationExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleValidationExceptionAsync(HttpContext context, ValidationException ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.BadRequest;

            var errors = ex.Errors.Select(e => e.ErrorMessage);
            var apiResp = JsonSerializer.Serialize(new ApiResponse(
                false,
                "Errors in data format validation.",
                errors));

            await response.WriteAsync(apiResp);
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            Log.Error(ex, "Something went wrong...");
            Log.CloseAndFlush();

            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var apiResp = JsonSerializer.Serialize(new ApiResponse(
                false,
                "A server error has occurred. Please contact the developer.",
                null));

            await response.WriteAsync(apiResp);
        }
    }
}
