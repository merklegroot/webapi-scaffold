using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using SimpleApi.Models;

namespace SimpleApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServerInfoController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var serverInfo = new ServerInfoResponseModel
        {
            Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production",
            Framework = Environment.Version.ToString(),
            OS = RuntimeInformation.OSDescription,
            Architecture = RuntimeInformation.OSArchitecture.ToString(),
            CurrentTime = DateTime.UtcNow,
            MachineName = Environment.MachineName
        };

        return Ok(serverInfo);
    }
} 