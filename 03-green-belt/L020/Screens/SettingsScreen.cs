using AbstractFactory.Theming;

namespace AbstractFactory.Screens;

/// <summary>
/// The call site, after the fix. It is handed one theme and asks that theme for
/// every part. It names no concrete class, and there is no combination of parts
/// it could ask for that would not match.
/// </summary>
public static class SettingsScreen
{
    public static Screen Draw(IScreenTheme theme)
    {
        IHeading heading = theme.CreateHeading();
        IButton button = theme.CreateButton();
        ICaption caption = theme.CreateCaption();

        return new Screen(
            new[] { heading.Style, button.Style, caption.Style },
            new[]
            {
                heading.Draw("Display settings"),
                button.Draw("Save"),
                caption.Draw("changes apply straight away")
            });
    }
}
