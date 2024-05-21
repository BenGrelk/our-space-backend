using Microsoft.AspNetCore.Mvc;
using our_place_backend.Models;
using our_place_backend.Services;

namespace our_place_backend.Controllers;

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
    
    [HttpPost($"{BaseRoute}/create")]
    public IActionResult Create([FromBody] CreateUserModel model)
    {
        var success = userServices.CreateUser(model);
        return success ? Ok("User created") : BadRequest("Failed to create user");
    }
    
    [HttpPut($"{BaseRoute}/update/{{userId}}")]
    public IActionResult Update(int userId, [FromBody] CreateUserModel model)
    {
        var success = userServices.UpdateUser(userId, model);
        return success ? Ok("User updated") : BadRequest("Failed to update user");
    }
    
    [HttpDelete($"{BaseRoute}/delete/{{userId}}")]
    public IActionResult Delete(int userId)
    {
        var success = userServices.DeleteUser(userId);
        return success ? Ok("User deleted") : BadRequest("Failed to delete user");
    }
}