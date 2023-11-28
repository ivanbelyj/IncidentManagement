using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace EventGenerator.Controllers.Events;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/events")]
[Produces("application/json")]
public class EventsController : ControllerBase
{
    private readonly Serilog.ILogger logger;

    public EventsController(Serilog.ILogger logger)
    {
        this.logger = logger;
        logger.Information("Created EventsController");
    }

    [ApiVersion("2.0")]
    [HttpGet("test")]
    public async Task<string> TestEndPoint2()
    {
        return "Hello v2!";
    }

    [HttpGet("")]
    public async Task<string> TestEndPoint()
    {
        
        return "Hello world!";
    }
}
