

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public override Task CreateRoomAsync(RoomModel newRoom)
    {
        throw new NotImplementedException();
    }

    public override async Task<List<RoomModel>> GetAllRoomsAsync()
    {
        List<RoomModel> rooms = (List<RoomModel>)_roomRepository.GetRooms();

        return rooms;
    }
}