using Microsoft.AspNetCore.Mvc;
using our_place_backend.Services;

namespace our_place_backend.Controllers
{
    public class UserController(UserServices userServices) : Controller
    {
        private const string BaseRoute = "/api/users";
        
        [HttpGet(BaseRoute)]
        public IActionResult Get()
        {
            return Ok("Hello from UserController");
        }

        [HttpGet($"{BaseRoute}/all")]
        public IActionResult GetAll()
        {
            var users = userServices.GetUsers();
            return Ok(users);
        }
    }
}