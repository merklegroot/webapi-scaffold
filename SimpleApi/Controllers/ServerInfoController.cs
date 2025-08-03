using Microsoft.AspNetCore.Mvc;
using Cortex.Mediator;
using SimpleApi.Queries;
using SimpleApi.Models;

namespace SimpleApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServerInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServerInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetServerInfoQuery();
        var result = await _mediator.SendQueryAsync<GetServerInfoQuery, ServerInfoResponseModel>(query);
        return Ok(result);
    }
} 