using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRExample.Hubs;
using SignalRExample.Models;
using System;
using System.Threading.Tasks;

namespace SignalRExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IHubContext<MessageHub, IMessageHub> _hubContext;

        public MessageController(IHubContext<MessageHub, IMessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] MessageModel msg)
        {
            msg.Timestamp = DateTime.Now.ToString();
            await _hubContext.Clients.All.BroadcastMessage(msg);
            return "Success";
        }
    }
}
