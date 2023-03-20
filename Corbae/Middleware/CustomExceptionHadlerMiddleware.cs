using Corbae.Exceptions.UserExceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using System.Reflection;

namespace Corbae.Middleware
{
    public class CustomExceptionHadlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHadlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch(ex)
            {
                case ValidationException validationException:
                    code=HttpStatusCode.BadRequest;
                    break;

                case EmailAlreadyInUseException emailAlreadyInUseException:
                    code = HttpStatusCode.BadRequest;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            result = JsonSerializer.Serialize(new
            {
                statuscode = code,
                message = ex.Message
            });
            return context.Response.WriteAsync(result);
        }
    }
}
