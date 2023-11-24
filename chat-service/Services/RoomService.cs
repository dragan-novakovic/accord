

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public override async Task CreateRoomAsync(RoomModel newRoom)
    {
        throw new NotImplementedException();
    }

    public override async Task<List<RoomModel>> GetAllRoomsAsync()
    {
        List<RoomModel> rooms = await _roomRepository.GetRooms();

        return rooms;
    }
}