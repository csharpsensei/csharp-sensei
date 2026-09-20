using PrototypePattern.Models;

namespace PrototypePattern.Sheets;

/// <summary>
/// A match day team sheet: who starts, who is on the bench, the shape and
/// the strip. This is the prototype. One of these is put together carefully
/// once, and every later sheet starts life as a copy of it.
/// </summary>
public sealed class TeamSheet
{
    public TeamSheet(
        string opponent,
        Formation formation,
        KitChoice kit,
        List<Player> starters,
        List<Player> substitutes)
    {
        Opponent = opponent;
        Formation = formation;
        Kit = kit;
        Starters = starters;
        Substitutes = substitutes;
    }

    public string Opponent { get; set; }

    public Formation Formation { get; set; }

    public KitChoice Kit { get; set; }

    public List<Player> Starters { get; set; }

    public List<Player> Substitutes { get; set; }

    /// <summary>
    /// A shallow copy. A new sheet, with every field's value copied
    /// across. For Kit, Starters and Substitutes the value IS the
    /// reference, so the copy shares all three with this sheet.
    /// </summary>
    public TeamSheet ShallowCopy()
    {
        return (TeamSheet)MemberwiseClone();
    }

    /// <summary>
    /// A deep copy. A new kit and two new lists, holding the same Player
    /// objects, because nothing here alters a Player and sharing one is safe.
    /// Every reference field is a decision. These are the decisions.
    /// </summary>
    public TeamSheet DeepCopy()
    {
        return new TeamSheet(
            Opponent,
            Formation,
            new KitChoice(Kit.Shirt, Kit.Shorts, Kit.Socks),
            new List<Player>(Starters),
            new List<Player>(Substitutes));
    }
}
