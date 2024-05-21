/*
 * Handles creation and deletion of channels
 */

using Microsoft.AspNetCore.Mvc;
using our_place_backend.Models;
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

    [HttpPost($"{BaseRoute}/create")]
    public IActionResult CreateChannel([FromBody] CreateChannelModel model)
    {
        var channel = channelServices.CreateChannel(model);
        return Ok(channel);
    }

    [HttpDelete($"{BaseRoute}/delete/{{channelId:int}}")]
    public IActionResult DeleteChannel(int channelId)
    {
        channelServices.DeleteChannel(channelId);
        return Ok();
    }

    [HttpPut($"{BaseRoute}/update/{{channelId:int}}")]
    public IActionResult UpdateChannel(int channelId, [FromBody] CreateChannelModel model)
    {
        channelServices.UpdateChannel(channelId, model);
        return Ok();
    }

    [HttpGet($"{BaseRoute}/{{channelId:int}}")]
    public IActionResult GetChannel(int channelId)
    {
        var channel = channelServices.GetChannelById(channelId);
        return Ok(channel);
    }
}