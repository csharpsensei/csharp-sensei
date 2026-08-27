using DesignPatterns.Board;
using DesignPatterns.Choosing;
using DesignPatterns.Legacy;
using DesignPatterns.Wrapping;

namespace DesignPatterns;

public static class Program
{
    public static void Main()
    {
        HandBuiltPass();
        Console.WriteLine();
        NamedPass();
        Console.WriteLine();
        QuietHoursPass();
    }

    /// <summary>One method doing all three jobs. Do not copy.</summary>
    private static void HandBuiltPass()
    {
        Console.WriteLine("Pass 1: one method, three problems (do not copy)");

        HandBuiltBoard board = new HandBuiltBoard();
        foreach (string row in board.Rows(quietHours: false))
        {
            Console.WriteLine("  " + row);
        }
    }

    /// <summary>
    /// The composition root: the one place that knows every concrete choice.
    /// Factory, adapter and policy, assembled by hand. No container anywhere.
    /// </summary>
    private static void NamedPass()
    {
        Console.WriteLine("Pass 2: three named solutions, same output");

        IDepartureSource source =
            new RegionalTimetableAdapter(new RegionalTimetable());
        DepartureBoard board = new DepartureBoard(source, new NormalPolicy());

        foreach (string row in board.Rows())
        {
            Console.WriteLine("  " + row);
        }
    }

    /// <summary>The same board, one constructor argument different.</summary>
    private static void QuietHoursPass()
    {
        Console.WriteLine("Pass 3: same board, quiet hours policy");

        IDepartureSource source =
            new RegionalTimetableAdapter(new RegionalTimetable());
        DepartureBoard board = new DepartureBoard(source, new QuietHoursPolicy());

        foreach (string row in board.Rows())
        {
            Console.WriteLine("  " + row);
        }
    }
}
