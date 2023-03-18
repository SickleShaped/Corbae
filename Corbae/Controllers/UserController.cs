using Corbae.BLL.Interfaces;
using Corbae.Exceptions.UserExceptions;
using Corbae.Models;
using Microsoft.AspNetCore.Mvc;
using Corbae.DAL.Models.DBModels;
using AutoMapper;
using Corbae.DAL.Models.DTO;

namespace Corbae.Controllers
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    [ApiController]
    [Route("/api/user")]
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;   
        }

        /// <summary>
        /// Get-запрос на получение всех пользователей
        /// </summary>
        /// <returns>List<User></User></returns>
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAll();
            return Json(users);
        }

        /// <summary>
        /// Get-запрос на получение пользователя по ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Json(User?)</returns>
        [HttpGet("GetUserByID")]
        public async Task<IActionResult> GetUserByID(Guid userId)
        {
            var user = await _userService.GetById(userId);
            return Json(user);
        }

        /// <summary>
        /// Post-Запрос на создание пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Guid</returns>
        [HttpPost("CreateUser")] //POST: /createuser
        public async Task<Guid> CreateUser(User user)
        {
            var newUserId = await _userService.Create(user);
            return newUserId;
        }


        /// <summary>
        /// Put-Запрос на выдавание пользователю полномочий админа
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("AddAdminCapability")]
        public void AddAdminCapability(Guid id)
        {
            _userService.AddAdminCapability(id);
        }

        /// <summary>
        /// Delete-запрос удаления пользователя по его ID
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("DeleteUser")]
        public void DeleteUser(Guid id)
        {
            _userService.Delete(id);
        }
    }






}
