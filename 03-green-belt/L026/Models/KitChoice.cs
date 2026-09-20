namespace PrototypePattern.Models;

/// <summary>
/// The strip the team plays in.
///
/// Mutable, because a kit clash is settled on the morning of the match. That
/// is exactly what makes it dangerous to share between two team sheets.
/// </summary>
public sealed class KitChoice
{
    public KitChoice(string shirt, string shorts, string socks)
    {
        Shirt = shirt;
        Shorts = shorts;
        Socks = socks;
    }

    public string Shirt { get; set; }

    public string Shorts { get; set; }

    public string Socks { get; set; }
}
