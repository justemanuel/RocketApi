using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RocketApi.Web.Models.DTOs;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace RocketApi.Web.Config
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong!: {ex.Message}");
                await HandlerGlobalExceptionAsync(context, ex);
            }
        }

        private static Task HandlerGlobalExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorDetails()
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                StatusCode = StatusCodes.Status500InternalServerError
            }));
        }
    }
}
