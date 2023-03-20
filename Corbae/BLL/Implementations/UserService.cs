using Corbae.BLL.Interfaces;
using Corbae.Models;
using Microsoft.EntityFrameworkCore;
using Corbae.Exceptions;
using Corbae.Exceptions.UserExceptions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.Mvc;
using System;
using Corbae.DAL;
using Corbae.BLL.Exceptions.UserExceptions;

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
            return await _dbContext.Users.Include(u => u.Orders).AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _dbContext.Users.Include(u => u.Orders).FirstOrDefaultAsync(u => u.UserID == id);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _dbContext.Users.Include(u => u.Orders).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Guid> Create(User user)
        {
            user.UserID = Guid.NewGuid();
            user.CreationDate = DateTime.UtcNow;
            var hash = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password);
            user.Password = hash;

            var emailuser = await GetByEmail(user.Email);
            if(emailuser != null)
            {
               throw new EmailAlreadyInUseException(user.Email);
            }

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.UserID;
        }

        public async void Delete(Guid id, string password)
        {
            var res = await _dbContext.Users.Where(u => u.UserID == id).ExecuteDeleteAsync();
            if(res==0)
            {
                throw new NoUserWithThatIdException(id);
            }
        }
    }
}
