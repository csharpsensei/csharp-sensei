public sealed class LightThemeFactory : IScreenTheme
{
    public string Style => "light";
    public IHeading CreateHeading() => new LightHeading();
    public IButton CreateButton() => new LightButton();
    public ICaption CreateCaption() => new LightCaption();
}

public sealed class HighContrastThemeFactory : IScreenTheme
{
    public string Style => "high-contrast";
    public IHeading CreateHeading() => new HighContrastHeading();
    public IButton CreateButton() => new HighContrastButton();
    public ICaption CreateCaption() => new HighContrastCaption();
}
