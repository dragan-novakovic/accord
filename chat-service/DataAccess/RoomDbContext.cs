using Microsoft.EntityFrameworkCore;

public class RoomDataContext : GenericDbContext
{
    public DbSet<RoomModel> Rooms { get; set; }

    public RoomDataContext(DbContextOptions<RoomDataContext> options) : base(options) { }
}