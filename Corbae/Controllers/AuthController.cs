using AutoMapper;
using Corbae.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    /// <summary>
    /// Контроллер аутентификации
    /// </summary>
    [ApiController]
    [Route("/api/auth")]
    public class AuthController:Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Войти в аккаунт пользователя
        /// </summary>
        /// <param name="user"> пользователь </param>
        /// <returns>Task<IResult</returns>
        [HttpGet("Login")]
        public async Task<string> Login(string email, string password)
        {
            return await _authService.Login(email, password);
        }
    }
}
