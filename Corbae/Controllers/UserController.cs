using Corbae.BLL;
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

        [HttpPost("CreateUser")] //POST: /createuser
        public async Task<IActionResult> CreateUser(User user)
        {
            var createdUser = await _serviceManager.UserService.Create(user);
            return Json(createdUser);
        }
    }


    
   


}
