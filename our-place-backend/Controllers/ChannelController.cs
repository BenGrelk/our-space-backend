/*
 * Handles creation and deletion of channels
 */

using Microsoft.AspNetCore.Mvc;
using our_place_backend.Services;

namespace our_place_backend.Controllers;

public class ChannelController(ChannelServices channelServices) : Controller
{
    private const string BaseRoute = "/api/channels";
    
    [HttpGet(BaseRoute)]
    public IActionResult Get()
    {
        return Ok("Hello from ChannelController");
    }

    [HttpGet($"{BaseRoute}/all")]
    public IActionResult GetAll()
    {
        var channels = channelServices.GetChannels();
        return Ok(channels);
    }
}