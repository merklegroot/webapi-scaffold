using Cortex.Mediator.Queries;
using SimpleApi.Models;

namespace SimpleApi.Queries;

public record GetServerInfoQuery : IQuery<ServerInfoResponseModel>; 