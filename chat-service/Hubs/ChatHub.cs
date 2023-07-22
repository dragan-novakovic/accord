using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        private IMessageService _messageService;
        private readonly IMemoryCache _cache;

        public ChatHub(IMemoryCache cache, IMessageService messageService)
        {

            _cache = cache;
            _messageService = messageService;
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
        public async Task SendMessage(string userId, string receiverId, string messageContent, string? roomId)
        {
            string connectionId = this.GetConnectionId();
            // SAVE samewhere
            _cache.Set(userId, connectionId);

            if (roomId != null)
            {
                if (roomId == receiverId)
                {
                    // send message to room
                }

                string? receiverConnectionId = (string?)_cache.Get(receiverId);
                if (receiverConnectionId != null)
                {
                    await Clients.User(receiverConnectionId).SendAsync(messageContent);
                }

            }

            MessageModel msg = new(userId, receiverId, messageContent, roomId);
            await this.SaveMessage(msg);


        }

        public async Task SaveMessage(MessageModel msg)
        {
            await _messageService.CreateAsync(msg);
        }
    }
}