using System.ComponentModel.DataAnnotations.Schema;

namespace our_place_backend.Models;

[Table("channels")]
public class Channel
{
    [Column("channel_id")] public int ChannelId { get; set; }

    [Column("channel_name")] public string ChannelName { get; set; }

    [Column("description")] public string Description { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("icon")] public byte[] Icon { get; set; }

    [Column("created_by_user_id")] public int? CreatedByUserId { get; set; }
}