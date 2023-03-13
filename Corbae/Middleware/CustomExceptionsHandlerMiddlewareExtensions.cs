namespace Corbae.Middleware
{
    public static class CustomExceptionsHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHadlerMiddleware>();
        }
    }
}
