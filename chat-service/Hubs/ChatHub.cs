using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        private IMessageService _messageService;

        public ChatHub(IMessageService messageService)
        {

            _messageService = messageService;
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task Send(string message)
        {

            MessageModel msg = new MessageModel(message, "CHAT SERVER 1", "DOTNET");
            await _messageService.CreateAsync(msg);
            await Clients.All.SendAsync("receive", message);
        }
    }
}