using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_IHubContext_Example.Hubs;

namespace SignalR_IHubContext_Example.Business
{
    public class MessageBusinnes
    {
        private readonly IHubContext<MessageHub> _hubContext;

        public MessageBusinnes(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        
        public async Task MessageAsync(string message, string user)
        {
            await _hubContext.Clients.All.SendAsync("receiverMessage", message, user);
        }

    }
}
