using Microsoft.AspNetCore.SignalR;

namespace AzSignalR.SignalRHubs
{
    public class MyHub : Hub<IHubClient>
    {
        private readonly Guid _engId = Guid.Parse("9C608297-70AB-4353-B7E5-ED9C85C4DDDC");

        public override async Task OnConnectedAsync() =>
            await this.Groups.AddToGroupAsync(Context.ConnectionId, _engId.ToString(), default);

        public async Task SendMessage(string user, string message) => await Clients.All.PushMessage(user, message);
        public async Task SendMessageToCaller(string user, string message) => await Clients.Caller.PushMessage(user, message);
        public async Task SendMessageExceptCaller(string user, string message) => await Clients.Others.PushMessage(user, message);

        public async Task OnDisconnectedAsync(Exception? exception, string group)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
            await base.OnDisconnectedAsync(exception);
        }
    }
}