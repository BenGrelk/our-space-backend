using our_place_backend.Data;
using our_place_backend.Models;

namespace our_place_backend.Services;

public class PostServices(MyDbContext context)
{
    public List<Post> GetChannels()
    {
        return context.Posts.ToList();
    }
}