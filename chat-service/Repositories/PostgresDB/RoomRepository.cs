
public class RoomRepository : GenericRepository<RoomModel>, IRoomRepository
{
    public RoomRepository(GenericDbContext _context) : base(_context)
    {
    }

    public IEnumerable<RoomModel> GetRooms()
    {
        return _context.Rooms.ToList();
    }
    public IEnumerable<RoomModel> GetRoomsForUser(string userId)
    {
        throw new NotImplementedException();
    }
}