using Corbae.Middleware;

namespace Corbae.Extensions
{
    /// <summary>
    /// Класс, предоставляющий расширение для обработки кастомных исключений
    /// </summary>
    public static class CustomExceptionsHandlerMiddlewareExtensions
    {
        /// <summary>
        /// Использование кастомных исключений
        /// </summary>
        /// <param name="builder"></param>
        /// <returns>builder.UseMiddleware<CustomExceptionHadlerMiddleware>()</returns>
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHadlerMiddleware>();
        }
    }
}
