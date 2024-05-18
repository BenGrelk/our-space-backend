using Microsoft.AspNetCore.Mvc;
using our_place_backend.Services;

namespace our_place_backend.Controllers
{
    public class UserController : Controller
    {
        private readonly UserServices _userServices;

        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("/user")]
        public IActionResult Get()
        {
            return Ok("Hello from UserController");
        }

        [HttpGet("/user/all")]
        public IActionResult GetAll()
        {
            var users = _userServices.GetUsers();
            return Ok(users);
        }
    }
}