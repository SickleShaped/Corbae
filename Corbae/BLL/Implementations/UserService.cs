using Corbae.BLL.Interfaces;
using Corbae.Models;
using Microsoft.EntityFrameworkCore;

namespace Corbae.BLL.Implementations
{
    public class UserService:IUserService
    {
        private readonly ApiDbContext _dbContext;

        public UserService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.Include(u => u.Orders).ToList();
        }

        public async Task<User?> GetById(string id)
        {
            return await _dbContext.Users.Include(u => u.Orders).FirstOrDefaultAsync(u => u.UserID == id);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _dbContext.Users.Include(u => u.Orders).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<string?> Create(User user)
        {
            user.UserID = Guid.NewGuid().ToString();

            var emailuser = GetByEmail(user.Email);
           // if(emailuser !=null)
           // {
            //    return 
            //}

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.UserID;
        }
    }
}
