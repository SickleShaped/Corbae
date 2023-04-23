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
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Corbae.DAL.Models.Auxiliary_Models;

namespace Corbae.BLL.Implementations
{
    /// <summary>
    /// Класс, в котором реализованы методы взаимодействия с пользователем
    /// </summary>
    public class UserService : IUserService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;

        public UserService(ApiDbContext dbContext, IMapper mapper, ICartService cartService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _cartService = cartService;
        }

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns>List<User></USER></returns>
        public async Task<List<User>> GetAll()
        {
            var UsersDB = await _dbContext.Users.AsNoTracking().ProjectTo<User>(_mapper.ConfigurationProvider).ToListAsync();
            return UsersDB;
        }

        /// <summary>
        /// Получить пользователя по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> User? </returns>
        public async Task<User?> GetById(Guid id)
        {
            return await _dbContext.Users.ProjectTo<User>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.UserID == id);
        }

        /// <summary>
        /// Получить пользователя по его почте 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User?> GetByEmail(string email)
        {
            return await _dbContext.Users.ProjectTo<User>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByPhoneNumber(string phoneNumber)
        {
            return await _dbContext.Users.ProjectTo<User>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.PhoneNumber==phoneNumber);
        }

       /// <summary>
       /// Изменить пользователя
       /// </summary>
       /// <param name="userData"></param>
       /// <param name="id"></param>
       /// <exception cref="UserNotFoundException"></exception>
       /// <exception cref="EmailAlreadyInUseException"></exception>
       /// <exception cref="PhoneNumberAlreadyInUseException"></exception>
        public async Task Edit(UserToCreate userData, Guid id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserID == id);
            if (user == null) throw new UserNotFoundException();

            var emailUser=GetByEmail(userData.Email);
            if(emailUser != null) throw new EmailAlreadyInUseException(userData.Email);

            var phoneNumberUser=GetByPhoneNumber(userData.PhoneNumber);
            if(phoneNumberUser != null) throw new PhoneNumberAlreadyInUseException(userData.PhoneNumber);

            user = _mapper.Map<UserDB>(userData);

            await _dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="user_"></param>
        /// <returns>Id пользователя</returns>
        /// <exception cref="EmailAlreadyInUseException"></exception>
        public async Task<Guid> Create(UserToCreate userDto)
        {
            var user = _mapper.Map<UserDB>(userDto);

            user.UserID = Guid.NewGuid();
            user.CreationDate = DateTime.UtcNow;
            var hash = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password);
            user.Password = hash;

            var emailuser = await GetByEmail(user.Email);
            if (emailuser != null) throw new EmailAlreadyInUseException(user.Email);

            var phoneNumberUser = await GetByPhoneNumber(user.PhoneNumber);
            if (phoneNumberUser != null) throw new PhoneNumberAlreadyInUseException(user.PhoneNumber);

            await _dbContext.Users.AddAsync(user );
            await _cartService.Create(user.UserID);
            await _dbContext.SaveChangesAsync( );

            return user.UserID;
        }

        /// <summary>
        /// Дать пользователю полномочия админа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        public async Task AddAdminCapability(Guid id)
        {
            var user = await _dbContext.Users.Include(u => u.Orders).FirstOrDefaultAsync(u => u.UserID == id);
            if (user == null) throw new UserNotFoundException();
            user.IsAdmin = true;
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить средств на счет пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <exception cref="UserNotFoundException"></exception>
        public async Task AddMoney(Guid id, uint amount)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserID == id);
            if (user == null) throw new UserNotFoundException();
            user.Money += amount;
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Снять деньги со счета пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="NotEnoughMoneyException"></exception>
        public async Task ReduceMoney(Guid id, uint amount)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserID == id);
            if (user == null) throw new UserNotFoundException();
            if (user.Money < amount) throw new NotEnoughMoneyException();
            user.Money -= amount;
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        public async Task Delete(Guid id)
        {
            var res = await _dbContext.Users.Where(u => u.UserID == id).ExecuteDeleteAsync();
            if (res == 0) throw new UserNotFoundException();
        }
    }
}
