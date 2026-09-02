namespace AbstractFactory.Theming.HighContrast;

/// <summary>
/// The second concrete family. A third one is this file again with three
/// different class names inside it, and no call site is touched.
/// </summary>
public sealed class HighContrastThemeFactory : IScreenTheme
{
    public string Style => "high-contrast";
    public IHeading CreateHeading() => new HighContrastHeading();
    public IButton CreateButton() => new HighContrastButton();
    public ICaption CreateCaption() => new HighContrastCaption();
}
