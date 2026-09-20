namespace PrototypePattern.Models;

/// <summary>
/// One named player.
///
/// Immutable on purpose. Nothing in this lesson ever changes a player's own
/// details, so a copied team sheet can share the very same Player instance
/// without any risk, and DeepCopy deliberately does not duplicate them.
/// </summary>
public sealed class Player
{
    public Player(string name, string position, int shirtNumber)
    {
        Name = name;
        Position = position;
        ShirtNumber = shirtNumber;
    }

    public string Name { get; }

    public string Position { get; }

    public int ShirtNumber { get; }
}
