using Corbae.Models;

namespace Corbae.BLL.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        List<User?> GetById(string id);
        Task<User?> Create(User user);
        Task<User?> Edit(User userData, User user);
    }
}
