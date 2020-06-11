using SignalRExample.Models;
using System.Threading.Tasks;

namespace SignalRExample.Hubs
{
    public interface IMessageHub
    {
        Task BroadcastMessage(MessageModel message);
    }
}
