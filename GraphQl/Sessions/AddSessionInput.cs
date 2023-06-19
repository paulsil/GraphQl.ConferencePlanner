using ConferencePlanner.GraphQL.Data;

public record AddSessionInput(
    string Title,
    string? Abstract,
    [ID(nameof(Speaker))]
    IReadOnlyList<int> SpeakerIds);