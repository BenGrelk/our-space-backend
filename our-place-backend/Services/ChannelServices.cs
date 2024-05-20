using our_place_backend.Data;
using our_place_backend.Models;

namespace our_place_backend.Services;

public class ChannelServices(MyDbContext context)
{
    public List<Channel> GetChannels()
    {
        return context.Channels.ToList();
    }
}