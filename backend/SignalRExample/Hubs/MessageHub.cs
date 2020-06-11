using Microsoft.AspNetCore.SignalR;
using SignalRExample.Models;
using System.Threading.Tasks;

namespace SignalRExample.Hubs
{
    public class MessageHub : Hub<IMessageHub>
    {
        public async Task BroadcastMessage(MessageModel message)
        {
            await Clients.All.BroadcastMessage(message);
        }
    }
}
