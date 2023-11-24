using System.ComponentModel.DataAnnotations;

public class UserMetadataModel
{

    public required int Id { get; set; }
    [Required]
    public required string Email { get; set; }

    public decimal Tokens { get; set; }
    public List<string>? Roles { get; set; }
    public List<UserMetadataModel>? Users { get; set; }

}