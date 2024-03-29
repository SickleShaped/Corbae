﻿using Corbae.BLL.Interfaces;
using Corbae.Exceptions.UserExceptions;
using Corbae.Models;
using Microsoft.AspNetCore.Mvc;
using Corbae.DAL.Models.DBModels;
using AutoMapper;
using Corbae.DAL.Models.DTO;
using Corbae.DAL.Models.Auxiliary_Models;
using Microsoft.AspNetCore.Authorization;

namespace Corbae.Controllers
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    [ApiController]
    [Route("/user")]
    public class UserController : Controller
    {

        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get-запрос на получение всех пользователей
        /// </summary>
        /// <returns>Task<IActionResult></User></returns>
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
        /// <returns>Task<IActionResult></returns>
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
        /// <returns>Task<Guid></returns>
        [HttpPost("CreateUser")] //POST: /createuser
        
        public async Task<Guid> CreateUser(UserToCreate user)
        {
            var newUserId = await _userService.Create(user);
            return newUserId;
        }

        /// <summary>
        /// Изменить пользователя
        /// </summary>
        /// <param name="userData"></param>
        /// <param name="id"></param>
        /// <returns>Task</returns>
        [HttpPut("EditUser")]
        [Authorize]
        public async Task Edit(UserToEdit userData, Guid id)
        {
            await _userService.Edit(userData, id);
        }

        /// <summary>
        /// Put-Запрос на выдавание пользователю полномочий админа
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task</returns>
        [HttpPut("AddAdminCapability")]
        [Authorize]
        public async Task AddAdminCapability(Guid id)
        {
            await _userService.AddAdminCapability(id);
        }

        /// <summary>
        /// Добавить деньги на счет пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="almount"></param>
        /// <returns>Task</returns>
        [HttpPut("AddMoney")]
        [Authorize]
        public async Task Add(Guid id, uint almount)
        {
            var i = HttpContext.Request.Headers.ToList();
            await _userService.AddMoney(id, almount);
        }

        /// <summary>
        /// Добавить деньги на счет пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="almount"></param>
        /// <returns>Task</returns>
        [HttpPut("ReduceMoney")]
        [Authorize]
        public async Task Reduce(Guid id, uint almount)
        {
            var i = HttpContext.Request.Headers.ToList();
            await _userService.ReduceMoney(id, almount);
        }

        /// <summary>
        /// Delete-запрос удаления пользователя по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task</returns>
        [HttpDelete("DeleteUser")]
        [Authorize]
        public async Task DeleteUser(Guid id)
        {
            await _userService.Delete(id);
        }
    }






}
