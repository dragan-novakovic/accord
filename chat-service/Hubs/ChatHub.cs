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
        public async Task SendMessage(string userId, string receiverId, string messageContent, string? roomId)
        {
            if (roomId != null)
            {

                MessageModel msg = new(userId, receiverId, messageContent, roomId);
                await Clients.All.SendAsync();
            }
            else
            {
                MessageModel msg = new(userId, receiverId, messageContent, roomId);

            }

        }

        public async Task SaveMessage(string user, string receiver, string message)
        {
            await _messageService.CreateAsync(msg);
        }
    }
}