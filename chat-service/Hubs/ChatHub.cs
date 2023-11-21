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


        public override async Task OnConnectedAsync()
        {
            // await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            Console.WriteLine($"User Identifier: {Context.UserIdentifier},  User: {Context.User}, Items: {Context.Items}");
            await base.OnConnectedAsync();
        }


        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
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

        public void AddToCache(string userId)
        {
            Func<ICacheEntry, List<string>> factory = entry =>
            {
                // Set some options for the cache entry, such as expiration
                // entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                return [];
            };


            string connectionId = GetConnectionId();
            Console.WriteLine("Mapping User " + userId + "=>" + connectionId);

            List<string>? userConnections = _cache.GetOrCreate(userId, factory);

            if (userConnections != null)
            {
                userConnections.Add(connectionId);
                _cache.Set(userId, userConnections);
            }


        }

        public async Task SendMessage(string userId, string messageContent, string receiverId = "None", string roomId = "None")
        {
            Console.WriteLine("Inside SendMessage Invocation");

            if (roomId != "None" && roomId != receiverId && receiverId == "None")
            {
                await AddToGroup(roomId);
                await Clients.Group(roomId).SendAsync("ReceiveMessage", messageContent);
            }

            // Get Receiver connections
            List<string>? receiverConnections = _cache.Get<List<string>>(receiverId);
            if (receiverConnections != null)
            {
                receiverConnections.ForEach(async connection =>
                {

                    Console.WriteLine($"Sending to user: {receiverId} with connection: {connection}");
                    await Clients.Client(connection).SendAsync("ReceiveMessage", messageContent);

                });

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