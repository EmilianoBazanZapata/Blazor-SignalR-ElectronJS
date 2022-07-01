using Microsoft.AspNetCore.SignalR;

namespace BlazorApp1.Data
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReciveMessage", user, message);
        }
    }
}
