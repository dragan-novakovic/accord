using System.ComponentModel.DataAnnotations;

public class RoomModel
{

    public required int Id { get; set; }
    [Required]
    public required string RoomName { get; set; }

    public List<string>? Users { get; set; }

}