using Corbae.BLL.Interfaces;
using Corbae.Models;
using Microsoft.EntityFrameworkCore;
using Corbae.Exceptions;
using Corbae.Exceptions.UserExceptions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.Mvc;
using Corbae.DAL;

namespace Corbae.BLL.Implementations
{
    public class UserService:IUserService
    {
        private readonly ApiDbContext _dbContext;

        public UserService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users.Include(u => u.Orders).ToListAsync();
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

            var hash = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password);
            user.Password = hash;
            
            if(emailuser !=null)
            {
                throw new EmailAlreadyInUseException(user.Email);
            }

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.UserID;
        }

        public async void Delete(string id)
        {
            var idUser = await GetById(id);
            if(idUser == null)
            {
                throw new NoUserWithThatIdException(id);
            }
            _dbContext.Users.Remove(idUser);
            await _dbContext.SaveChangesAsync();
        }
    }
}
