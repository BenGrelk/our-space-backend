using System.ComponentModel.DataAnnotations;

namespace our_place_backend.Models;

public class CreateChannelModel
{
    [Required] public string Name { get; set; }

    [Required] public int CreatedByUserId { get; set; }

    public string? Description { get; set; }

    public byte[]? Icon { get; set; }
}