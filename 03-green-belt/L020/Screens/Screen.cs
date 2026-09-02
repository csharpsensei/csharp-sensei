namespace AbstractFactory.Screens;

/// <summary>
/// A drawn screen, plus the family every part of it came from. The styles are
/// carried only so this lesson can prove agreement at runtime rather than
/// claim it.
/// </summary>
public sealed record Screen(
    IReadOnlyList<string> Styles,
    IReadOnlyList<string> Lines)
{
    public bool PartsAgree => Styles.Distinct().Count() == 1;
}
