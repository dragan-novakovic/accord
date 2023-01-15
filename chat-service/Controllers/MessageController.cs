using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    public async Task<List<MessageModel>> GetAllMessages()
    {
        return await _messageService.GetAsync();
    }
}
