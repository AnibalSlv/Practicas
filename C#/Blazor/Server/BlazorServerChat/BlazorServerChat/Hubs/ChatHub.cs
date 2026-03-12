using Microsoft.AspNetCore.SignalR;

namespace BlazorServerChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user, message);
            //SendAsync: Ejecuta el metodo entre "" con los parametros user y message

        }
    }
}
