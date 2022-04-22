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
            Console.WriteLine("OJ");
        }

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("receive", message);
            var Poruka = new MessageModel("nzm", "sss", "qqqq");
            var messagesList = _messageService.CreateAsync(Poruka);
            Console.WriteLine("2", messagesList.ToString(), "HMM");
        }
    }
}