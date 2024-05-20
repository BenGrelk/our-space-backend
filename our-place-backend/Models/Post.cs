using System.ComponentModel.DataAnnotations.Schema;

namespace our_place_backend.Models;

[Table("posts")]
public class Post
{
    [Column("post_id")] public int PostId { get; set; }

    [Column("creator_user_id")] public int CreatorUserId { get; set; }

    [Column("channel_id")] public int? ChannelId { get; set; }

    [Column("attachment")] public byte[] Attachment { get; set; }

    [Column("message")] public string Message { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }
}