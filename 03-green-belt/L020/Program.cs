using AbstractFactory.Legacy;
using AbstractFactory.Screens;
using AbstractFactory.Theming;
using AbstractFactory.Theming.HighContrast;
using AbstractFactory.Theming.Light;

namespace AbstractFactory;

public static class Program
{
    public static void Main()
    {
        HandBuiltPass();
        Console.WriteLine();
        OneThemePass();
        Console.WriteLine();
        BothThemesPass();
    }

    /// <summary>Three parts, three separate decisions, one screen. Do not copy.</summary>
    private static void HandBuiltPass()
    {
        Console.WriteLine("Pass 1: three parts, three separate decisions (do not copy)");
        Print(HandBuiltScreen.Draw("high-contrast"));
    }

    /// <summary>
    /// One theme, asked for every part. The screen is drawn by the same code as
    /// pass one, and the parts now agree because nothing here can pick them
    /// separately.
    /// </summary>
    private static void OneThemePass()
    {
        Console.WriteLine("Pass 2: one theme, one decision");
        Print(SettingsScreen.Draw(new HighContrastThemeFactory()));
    }

    /// <summary>
    /// The same call site, run against both families. Nothing in SettingsScreen
    /// changes between these two runs, which is what the pattern buys.
    /// </summary>
    private static void BothThemesPass()
    {
        Console.WriteLine("Pass 3: one call site, both themes");

        IScreenTheme[] themes =
        {
            new LightThemeFactory(),
            new HighContrastThemeFactory()
        };

        foreach (IScreenTheme theme in themes)
        {
            Console.WriteLine("  Theme: " + theme.Style);
            Print(SettingsScreen.Draw(theme));
        }
    }

    private static void Print(Screen screen)
    {
        Console.WriteLine("  Parts agree: " + screen.PartsAgree);
        foreach (string line in screen.Lines)
        {
            Console.WriteLine("  " + line);
        }
    }
}
