using System.ComponentModel.DataAnnotations;

namespace our_place_backend.Models;

public class CreatePostModel
{
    [Required] public int UserId { get; set; }
    [Required] public string Message { get; set; }
    public byte[]? Attachment { get; set; }
}