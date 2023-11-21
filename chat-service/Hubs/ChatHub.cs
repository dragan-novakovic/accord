using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;
        private readonly IMemoryCache _cache;

        public ChatHub(IMemoryCache cache, IMessageService messageService)
        {

            _cache = cache;
            _messageService = messageService;
        }

        // ConnectionID that will indentify the User
        public string GetConnectionId()
        {

            return Context.ConnectionId;
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(GetConnectionId(), groupName);
        }

        public async Task SendMessage(string userId, string messageContent, string receiverId, string roomId = "None")
        {
            Console.WriteLine("Inside SendMessage Invocation");
            string connectionId = GetConnectionId();
            // SAVE samewhere
            Console.WriteLine("Mapping User " + userId + "=>" + connectionId);
            _cache.Set(userId, connectionId);

            if (roomId != "None" && roomId != receiverId)
            {
                await AddToGroup(roomId);
            }


            string? receiverConnectionId = (string?)_cache.Get(receiverId);
            if (receiverConnectionId != null)
            {
                Console.WriteLine($"Sending to user: {receiverId} with connection: {receiverConnectionId}");
                await Clients.User(receiverConnectionId).SendAsync(messageContent);
            }
            else
            {
                Console.WriteLine($"User not Mapped in Cache - {receiverId}");

            }


            MessageModel msg = new(userId, receiverId, messageContent, roomId);
            await SaveMessage(msg);


        }


        public async Task BroadcastMessage(string messageContent)
        {

            await Clients.All.SendAsync(messageContent);
        }

        public async Task SaveMessage(MessageModel msg)
        {
            Console.WriteLine($"TODO: Save to DB");
            // await _messageService.CreateAsync(msg);
        }
    }
}