namespace PrototypePattern.Legacy;

/// <summary>
/// DO NOT COPY THIS SHAPE. It is here to make one point and nothing else.
///
/// This type implements ICloneable and its Clone is SHALLOW. The notes list is
/// shared with the original. Nothing at the call site says so, because
/// ICloneable.Clone returns object and has never said which kind of copy you
/// are getting. Compare it with LegacyRota, which is deep.
/// </summary>
public sealed class LegacySheet : ICloneable
{
    public LegacySheet(string opponent, List<string> notes)
    {
        Opponent = opponent;
        Notes = notes;
    }

    public string Opponent { get; set; }

    public List<string> Notes { get; set; }

    public object Clone()
    {
        return MemberwiseClone();
    }
}
