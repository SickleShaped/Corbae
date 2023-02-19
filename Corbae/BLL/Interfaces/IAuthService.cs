using Corbae.Models;

namespace Corbae.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<User> SingUp(User user);
        string JwtIssue(User user);
    }
}
