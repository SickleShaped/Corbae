using Corbae.BLL.Exceptions.UserExceptions;
using Corbae.BLL.Interfaces;
using Corbae.DAL;
using Corbae.DAL.Models.Auxiliary_Models;
using Corbae.DAL.Models.DTO;
using Corbae.Extensions;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Corbae.BLL.Implementations
{
    /// <summary>
    /// Класс, в котором реализованы методы взаимодействия с аутентификацией
    /// </summary>
    public class AuthService:IAuthService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IUserService _userService;

        public AuthService(ApiDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        /// <summary>
        /// Залогинить пользвоателя
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="WrongPasswordException"></exception>
        public async Task<LoginResponse> Login(string email, string password)
        {
            var user_ = await _userService.GetByEmail(email);
            if (user_ == null) throw new UserNotFoundException();
            if(BCrypt.Net.BCrypt.EnhancedVerify(password, user_.Password) == false) throw new WrongPasswordException();
            var jwt = await JwtIssue(user_);
            var response = new LoginResponse();
            response.Jwt=jwt;
            response.UserId = user_.UserID;
            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow.Add(TimeSpan.FromDays(30));
            response.Expires = now.ToUnixTimeSeconds();

            return response;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> JwtIssue(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.UserID))
            
            };

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(30)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
