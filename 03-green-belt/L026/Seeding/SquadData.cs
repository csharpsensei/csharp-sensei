using PrototypePattern.Models;
using PrototypePattern.Sheets;

namespace PrototypePattern.Seeding;

/// <summary>
/// The squad, fixed in code so the output is the same on any machine on any
/// day. No dates, no money and no culture sensitive formatting anywhere in
/// this lesson, deliberately.
/// </summary>
public static class SquadData
{
    public static TeamSheet MatchDayTemplate()
    {
        List<Player> starters = new List<Player>
        {
            new Player("Whitlock", "GK", 1),
            new Player("Barrow", "DF", 2),
            new Player("Nkemdi", "DF", 5),
            new Player("Haines", "DF", 6),
            new Player("Pryce", "DF", 3),
            new Player("Ferris", "MF", 8),
            new Player("Adeyemi", "MF", 4),
            new Player("Corrigan", "MF", 7),
            new Player("Stanic", "MF", 11),
            new Player("Bellamy", "FW", 9),
            new Player("Odell", "FW", 10)
        };

        List<Player> substitutes = new List<Player>
        {
            new Player("Doyle", "GK", 12),
            new Player("Shah", "DF", 14),
            new Player("Okafor", "FW", 19)
        };

        KitChoice kit = new KitChoice("amber", "black", "amber");

        return new TeamSheet("Hartley Rovers", Formation.FourFourTwo, kit, starters, substitutes);
    }
}
