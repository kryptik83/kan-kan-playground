using AzSignalR.SignalRHubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AzSignalR.Controllers;

[ApiController]
[Route("[controller]")]
public class SignalRController : ControllerBase
{


    private readonly ILogger<SignalRController> _logger;
    private readonly IHubContext<MyHub, IHubClient> _hub;

    public SignalRController(ILogger<SignalRController> logger, IHubContext<MyHub, IHubClient> hub)
    {
        _logger = logger;
        _hub = hub;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task Get(string userName = "VK", string userMessage = "Hi!")
    {
        var g = Guid.NewGuid().ToString();
        //await _hub.Groups.AddToGroupAsync(HttpContext.Connection.Id, g);
        //var abc = _hub.Clients;
        await _hub.Clients.All.PushMessage(userName, userMessage);
        // await _hub.Clients.Group(g).SendAsync("RA");
    }
}