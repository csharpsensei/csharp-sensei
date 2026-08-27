using DesignPatterns.Creating;

namespace DesignPatterns.Board;

/// <summary>One row on the departure board, in the board's own vocabulary.</summary>
public sealed record Departure(
    IService Service,
    string Destination,
    TimeOnly Due,
    int DelayMinutes);
