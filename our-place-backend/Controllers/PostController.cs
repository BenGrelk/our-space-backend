/*
 * Handles viewing, creation, and deletion of posts
 */

using Microsoft.AspNetCore.Mvc;
using our_place_backend.Services;

namespace our_place_backend.Controllers;

public class PostController(PostServices postServices) : Controller
{
    private const string BaseRoute = "/api/posts";
    
    [HttpGet(BaseRoute)]
    public IActionResult Get()
    {
        return Ok("Hello from ChannelController");
    }

    [HttpGet($"{BaseRoute}/all")]
    public IActionResult GetAll()
    {
        var channels = postServices.GetChannels();
        return Ok(channels);
    }
}