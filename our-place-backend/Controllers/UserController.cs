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

    [HttpPost($"{BaseRoute}/create")]
    public IActionResult Create([FromBody] CreateUserModel model)
    {
        var user = userServices.CreateUser(model);
        return user != null ? Ok(user) : BadRequest("Failed to create user");
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
    
    [HttpGet($"{BaseRoute}/{{userId}}")]
    public IActionResult GetUser(int userId)
    {
        var user = userServices.GetUser(userId);
        return user != null ? Ok(user) : NotFound("User not found");
    }
    
    [HttpPost($"{BaseRoute}/signin")]
    public IActionResult SignIn([FromBody] SignInModel model)
    {
        var user = userServices.AuthenticateUser(model);
        return user != null ? Ok(user) : Unauthorized("Invalid credentials");
    }
}