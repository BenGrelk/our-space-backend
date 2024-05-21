using System.ComponentModel.DataAnnotations;

namespace our_place_backend.Models;

public class CreateUserModel
{
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public string? DisplayName { get; set; }
    public string? Status { get; set; }
    public string? Description { get; set; }
    public string? Settings { get; set; }
    public byte[]? Banner { get; set; }
}