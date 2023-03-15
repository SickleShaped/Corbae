using Corbae.BLL.Interfaces;
using Corbae.Exceptions.UserExceptions;
using Corbae.Models;
using Microsoft.AspNetCore.Mvc;
using Corbae.DAL.Models.DBModels;
using AutoMapper;
using Corbae.DAL.Models.DTO;

namespace Corbae.Controllers
{
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

        [HttpGet("GetUserByID")]
        public async Task<IActionResult> GetUserByID(Guid userId)
        {
            var orders = await _userService.GetById(userId);
            return Json(orders);
        }

        [HttpPost("CreateUser")] //POST: /createuser
        public async Task<Guid> CreateUser(User user)
        {
            var user_ = _mapper.Map<UserDB>(user);
            var newUserId = await _userService.Create(user_);
            return newUserId;
        }

        [HttpDelete("DeleteUser")]
        public async void DeleteUser(Guid id, string password)
        {
            _userService.Delete(id, password);
        }

    }






}
