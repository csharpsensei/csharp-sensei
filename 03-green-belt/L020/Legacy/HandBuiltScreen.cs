using AbstractFactory.Screens;
using AbstractFactory.Theming;
using AbstractFactory.Theming.HighContrast;
using AbstractFactory.Theming.Light;

namespace AbstractFactory.Legacy;

/// <summary>
/// The same screen before the fix. Do not copy this.
///
/// Three parts, and each one is chosen on its own line. High contrast reached
/// the heading and the caption. The button was missed. Nothing here is broken
/// enough to fail a build, and the screen it draws is wrong.
/// </summary>
public static class HandBuiltScreen
{
    public static Screen Draw(string mode)
    {
        IHeading heading = mode == "high-contrast"
            ? new HighContrastHeading()
            : new LightHeading();

        IButton button = new LightButton();

        ICaption caption = mode == "high-contrast"
            ? new HighContrastCaption()
            : new LightCaption();

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
