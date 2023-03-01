using Corbae.BLL;
using Corbae.Exceptions.UserExceptions;
using Corbae.Models;
using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class UserController : Controller
    {
        private readonly ServiceManager _serviceManager;

        public UserController(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("GetUserByID")]
        public async Task<IActionResult> GetUserByID(string userId)
        {
            var orders = await _serviceManager.UserService.GetById(userId);
            return Json(orders);
        }

        [HttpPost("CreateUser")] //POST: /createuser
        public async Task<string> CreateUser(User user)
        {
            var newUserId = await _serviceManager.UserService.Create(user);
            return newUserId.ToString();
        }

    }






}
