using System.ComponentModel.DataAnnotations.Schema;

namespace our_place_backend.Models;

[Table("users")]
public class User
{
    [Column("user_id")] public int UserId { get; set; }

    [Column("username")] public string Username { get; set; }

    [Column("profile_picture")] public byte[]? ProfilePicture { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }

    [Column("password")] public string Password { get; set; }

    [Column("display_name")] public string? DisplayName { get; set; }

    [Column("status")] public string? Status { get; set; }

    [Column("description")] public string? Description { get; set; }

    [Column("settings")] public string? Settings { get; set; }

    [Column("banner")] public int? Banner { get; set; }
}