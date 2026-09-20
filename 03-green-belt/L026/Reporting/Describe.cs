using PrototypePattern.Models;
using PrototypePattern.Modern;
using PrototypePattern.Sheets;

namespace PrototypePattern.Reporting;

/// <summary>Turns a sheet or a note into one readable line of output.</summary>
public static class Describe
{
    public static string Line(TeamSheet sheet)
    {
        return sheet.Opponent.PadRight(15)
             + Shape(sheet.Formation).PadRight(7)
             + sheet.Kit.Shirt.PadRight(7)
             + "subs: " + Names(sheet.Substitutes);
    }

    public static string Note(SquadNote note)
    {
        return note.Opponent.PadRight(15)
             + Shape(note.Formation).PadRight(7)
             + "missing: " + string.Join(", ", note.Unavailable);
    }

    public static string Shape(Formation formation)
    {
        return formation switch
        {
            Formation.FourFourTwo => "4-4-2",
            Formation.FourThreeThree => "4-3-3",
            _ => "3-5-2"
        };
    }

    public static string Names(List<Player> players)
    {
        return string.Join(", ", players.Select(player => player.Name));
    }

    public static string YesNo(bool value)
    {
        return value ? "yes" : "no";
    }
}
