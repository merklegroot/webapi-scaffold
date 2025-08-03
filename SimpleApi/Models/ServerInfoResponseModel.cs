namespace SimpleApi.Models;

public record ServerInfoResponseModel
{
    public required string Environment { get; init; }
    public required string Framework { get; init; }
    public required string OS { get; init; }
    public required string Architecture { get; init; }
    public required DateTime CurrentTime { get; init; }
    public required string MachineName { get; init; }
} 