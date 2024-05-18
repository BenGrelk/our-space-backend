using Microsoft.AspNetCore.Mvc;

namespace our_place_backend.Controllers;

public class UserController : Controller
{
    [HttpGet("/user")]
    public IActionResult Get()
    {
        return Ok("Hello from UserController");
    }
    
    [HttpGet("/user/{id}")]
    public IActionResult Get(int id)
    {
        return Ok($"Hello from UserController with id {id}");
    }
}