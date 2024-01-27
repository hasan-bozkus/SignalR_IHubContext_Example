using Microsoft.AspNetCore.SignalR;

namespace SignalR_IHubContext_Example.Hubs
{
    public class MessageHub : Hub
    {
        List<string> clients = new List<string>();
        //public async Task SendMessageAsync(string message, string user)
        //{
        //    await Clients.All.SendAsync("receiverMessage", message, user);
        //}

        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.SendAsync("userJoined", Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
        }
    }
}
