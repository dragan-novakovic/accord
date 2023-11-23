using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBase
{
    private readonly IMessageService _messageService;

    public RoomController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    public async Task<List<MessageModel>> GetAllMessages()
    {
        return await _messageService.GetAsync();
    }
}
