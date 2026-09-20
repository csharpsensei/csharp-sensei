using PrototypePattern.Models;

namespace PrototypePattern.Modern;

/// <summary>
/// The same idea as a team sheet, written as a record so the lesson can show
/// what a with expression does and, more to the point, what it does not do.
/// Unavailable is a list, so a with expression hands the copy the same list.
/// </summary>
public sealed record SquadNote(string Opponent, Formation Formation, List<string> Unavailable);
