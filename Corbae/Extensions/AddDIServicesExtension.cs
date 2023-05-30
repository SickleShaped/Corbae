using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Corbae.BLL.Implementations;
using Corbae.BLL.Interfaces;

namespace Corbae.Extensions
{
    /// <summary>
    /// Класс, предорставляющий расширение с внедрением зависимостей
    /// </summary>
    public static class AddDIServicesExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IWishService, WishService>();
           

            return services;
        }
    }
}
