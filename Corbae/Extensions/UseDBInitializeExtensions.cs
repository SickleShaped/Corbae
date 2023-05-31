using System.Runtime.CompilerServices;
using Corbae.DAL;

namespace Corbae.Extensions
{
    /// <summary>
    /// Класс, предоставляющий расширение с инициализацией БД
    /// </summary>
    public static class UseDBInitializeExtensions
    {
        /// <summary>
        /// Инициализация БД
        /// </summary>
        /// <param name="app"></param>
        public static void UseDBInitialize(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<ApiDbContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception e)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, $"An error occured while initializing the database: {e.Message}");
                }
            }
        }
    }
}
