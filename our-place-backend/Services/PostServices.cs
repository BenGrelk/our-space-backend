using our_place_backend.Data;
using our_place_backend.Models;

namespace our_place_backend.Services;

public class PostServices(MyDbContext context)
{
    public List<Post> GetChannels()
    {
        return context.Posts.ToList().OrderByDescending(post => post.CreatedAt).Reverse().ToList();
    }

    public List<Post> GetPostsByChannel(int channelId)
    {
        return context.Posts.Where(post => post.ChannelId == channelId).ToList();
    }

    public void CreatePost(int channelId, CreatePostModel model)
    {
        var id = context.Posts.Max(post => post.PostId) + 1;

        var newPost = new Post
        {
            PostId = id,
            CreatorUserId = model.UserId,
            ChannelId = channelId,
            Message = model.Message,
            CreatedAt = DateTime.UtcNow,
            Attachment = model.Attachment
        };

        context.Posts.Add(newPost);
        context.SaveChanges();
    }

    public bool DeletePost(int postId)
    {
        var post = context.Posts.Find(postId);

        if (post == null) return false;

        context.Posts.Remove(post);
        context.SaveChanges();

        return true;
    }

    public bool UpdatePost(int postId, CreatePostModel model)
    {
        var post = context.Posts.Find(postId);

        if (post == null) return false;

        post.Message = model.Message;
        post.Attachment = model.Attachment;

        context.SaveChanges();

        return true;
    }

    public Post? GetPost(int postId)
    {
        return context.Posts.Find(postId);
    }

    public List<Post> GetPostsByUser(int userId)
    {
        return context.Posts.Where(post => post.CreatorUserId == userId).ToList();
    }

    public List<Post> GetPostsByChannelAndUser(int channelId, int userId)
    {
        return context.Posts.Where(post => post.ChannelId == channelId && post.CreatorUserId == userId).ToList();
    }
}