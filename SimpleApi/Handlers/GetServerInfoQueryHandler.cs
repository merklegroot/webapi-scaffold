using Cortex.Mediator.Queries;
using System.Runtime.InteropServices;
using SimpleApi.Models;
using SimpleApi.Queries;

namespace SimpleApi.Handlers;

public class GetServerInfoQueryHandler : IQueryHandler<GetServerInfoQuery, ServerInfoResponseModel>
{
    public Task<ServerInfoResponseModel> Handle(GetServerInfoQuery request, CancellationToken cancellationToken)
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

        return Task.FromResult(serverInfo);
    }
} 