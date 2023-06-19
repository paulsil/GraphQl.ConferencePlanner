using ConferencePlanner.GraphQL.Data;

public record ScheduleSessionInput(
    [ID(nameof(Session))]
    int SessionId,
    [ID(nameof(Track))]
    int TrackId,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);