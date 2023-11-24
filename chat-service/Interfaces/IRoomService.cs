
public abstract class IRoomService
{
    public abstract Task<List<RoomModel>> GetAllRoomsAsync();
    public abstract Task CreateRoomAsync(RoomModel newRoom);
}