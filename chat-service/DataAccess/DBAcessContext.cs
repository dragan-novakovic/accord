using Microsoft.EntityFrameworkCore;

public class RoomDataContext : DbContext
{
    public DbSet<RoomModel> Rooms { get; set; }

    public RoomDataContext(DbContextOptions<RoomDataContext> options) : base(options) { }
}