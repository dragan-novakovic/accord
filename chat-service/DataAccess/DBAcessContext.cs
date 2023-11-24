using Microsoft.EntityFrameworkCore;

public class GenericDbContext(DbContextOptions<RoomDataContext> options) : DbContext(options)
{
    public DbSet<RoomModel> Rooms { get; set; }
    public DbSet<UserMetadataModel> UsersMetadata { get; set; }
}