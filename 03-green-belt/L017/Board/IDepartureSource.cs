namespace DesignPatterns.Board;

/// <summary>
/// What the board needs from a feed. The board owns this wording. A feed that
/// speaks a different shape is adapted to it, never the other way round.
/// </summary>
public interface IDepartureSource
{
    IReadOnlyList<Departure> Next();
}
