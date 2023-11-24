

public interface IRoomRepository : IGenericRepository<RoomModel>
{
    //Here, you need to define the operations which are specific to Room Entity
    Task<List<RoomModel>> GetRooms();
    IEnumerable<RoomModel> GetRoomsForUser(string userId);
}