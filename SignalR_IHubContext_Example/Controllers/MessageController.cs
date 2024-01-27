using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_IHubContext_Example.Business;
using SignalR_IHubContext_Example.Hubs;

namespace SignalR_IHubContext_Example.Controllers
{
    public class MessageController : Controller
    {
        private readonly MessageBusinnes _messageBusinnes;
        private readonly IHubContext<MessageHub> _hubContext;

        public MessageController(MessageBusinnes messageBusinnes, IHubContext<MessageHub> hubContext)
        {
            _messageBusinnes = messageBusinnes;
            _hubContext = hubContext;
        }


        public async Task<IActionResult> Index(string message, string user)
        {
            message = "SelamünAleyküm";
            user = "Admin";

            //await _messageBusinnes.MessageAsync("SelamünAleyküm", "Admin");
            await _hubContext.Clients.All.SendAsync("receiverMessage", message, user);
            return Ok();
            
        }



    }
}
