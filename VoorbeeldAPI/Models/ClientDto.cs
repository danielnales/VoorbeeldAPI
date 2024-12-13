namespace VoorbeeldAPI.Models;

public record ClientDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Phone { get; init; }
}
