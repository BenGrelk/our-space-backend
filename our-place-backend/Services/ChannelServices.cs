using our_place_backend.Data;
using our_place_backend.Models;

namespace our_place_backend.Services;

public class ChannelServices(MyDbContext context)
{
    public List<Channel> GetChannels()
    {
        return context.Channels.ToList();
    }

    public Channel? CreateChannel(CreateChannelModel model)
    {
        var channelId = context.Channels.Count() + 1;
        var timestamp = DateTime.UtcNow;

        var channel = new Channel
        {
            ChannelId = channelId,
            ChannelName = model.Name,
            Description = model.Description,
            CreatedAt = timestamp,
            Icon = model.Icon,
            CreatedByUserId = model.CreatedByUserId
        };

        context.Channels.Add(channel);
        context.SaveChanges();

        return channel;
    }

    public Channel? GetChannelById(int channelId)
    {
        return context.Channels.FirstOrDefault(channel => channel.ChannelId == channelId);
    }

    public void DeleteChannel(int channelId)
    {
        var channel = GetChannelById(channelId);
        if (channel != null)
        {
            context.Channels.Remove(channel);
            context.SaveChanges();
        }
    }

    public void UpdateChannel(int channelId, CreateChannelModel model)
    {
        var channel = GetChannelById(channelId);
        if (channel != null)
        {
            channel.ChannelName = model.Name;
            channel.Description = model.Description;
            channel.Icon = model.Icon;
            context.SaveChanges();
        }
    }
}