namespace AbstractFactory.Theming.Light;

/// <summary>
/// One concrete family. Every part it builds is a light part, and there is no
/// route through this class that returns anything else.
/// </summary>
public sealed class LightThemeFactory : IScreenTheme
{
    public string Style => "light";
    public IHeading CreateHeading() => new LightHeading();
    public IButton CreateButton() => new LightButton();
    public ICaption CreateCaption() => new LightCaption();
}
