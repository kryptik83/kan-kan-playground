namespace AzSignalR.SignalRHubs;

public interface IHubClient
{
    Task PushMessage(string userName, string userEventMessage);
}