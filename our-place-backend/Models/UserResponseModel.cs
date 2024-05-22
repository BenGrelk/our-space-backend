namespace our_place_backend.Models;

public class UserResponseModel
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? DisplayName { get; set; }
    public string? Status { get; set; }
    public string? Description { get; set; }
    public string? Settings { get; set; }
    public byte[]? Banner { get; set; }
}