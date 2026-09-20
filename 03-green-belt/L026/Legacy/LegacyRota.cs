namespace PrototypePattern.Legacy;

/// <summary>
/// DO NOT COPY THIS SHAPE either, for the same reason.
///
/// This type also implements ICloneable, and its Clone is DEEP. It is correct,
/// careful code. The problem is that a caller holding an ICloneable cannot
/// tell it apart from LegacySheet, and the two behave in opposite ways.
/// </summary>
public sealed class LegacyRota : ICloneable
{
    public LegacyRota(string opponent, List<string> notes)
    {
        Opponent = opponent;
        Notes = notes;
    }

    public string Opponent { get; set; }

    public List<string> Notes { get; set; }

    public object Clone()
    {
        return new LegacyRota(Opponent, new List<string>(Notes));
    }
}
