/*
 * Handles viewing, creation, and deletion of posts
 */

using Microsoft.AspNetCore.Mvc;
using our_place_backend.Models;
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

    [HttpGet("/api/channels/{channelId}/posts")]
    public IActionResult GetPostsByChannel(int channelId)
    {
        var posts = postServices.GetPostsByChannel(channelId);
        return Ok(posts);
    }

    [HttpPost("/api/channels/{channelId}/create")]
    public IActionResult CreatePost(int channelId, [FromBody] CreatePostModel post)
    {
        postServices.CreatePost(channelId, post);
        return Ok();
    }

    [HttpDelete("/api/channels/{channelId}/posts/{postId}")]
    public IActionResult DeletePost(int channelId, int postId)
    {
        var success = postServices.DeletePost(postId);

        if (!success) return NotFound();

        return Ok();
    }

    [HttpPut("/api/channels/{channelId}/posts/{postId}")]
    public IActionResult UpdatePost(int channelId, int postId, [FromBody] CreatePostModel post)
    {
        var success = postServices.UpdatePost(postId, post);

        if (!success) return NotFound();

        return Ok();
    }

    [HttpGet("/api/channels/{channelId}/posts/{postId}")]
    public IActionResult GetPost(int channelId, int postId)
    {
        var post = postServices.GetPost(postId);

        if (post == null) return NotFound();

        return Ok(post);
    }
}