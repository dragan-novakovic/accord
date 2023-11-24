
using Microsoft.EntityFrameworkCore;

public class RoomRepository : GenericRepository<RoomModel>, IRoomRepository
{
    public RoomRepository(GenericDbContext _context) : base(_context)
    {
    }

    public async Task<List<RoomModel>> GetRooms()
    {
        return await _context.Rooms.ToListAsync();
    }
    public IEnumerable<RoomModel> GetRoomsForUser(string userId)
    {
        throw new NotImplementedException();
    }
}