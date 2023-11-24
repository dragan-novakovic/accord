using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService, IMessageService messageService)
    {
        _messageService = messageService;
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<List<MessageModel>> GetAllMessages()
    {
        return await _messageService.GetAsync();
    }


    [HttpGet]
    public async Task<List<RoomModel>> GetAllRooms()
    {
        return await _roomService.GetAllRoomsAsync();
    }
}
