namespace AbstractFactory.Theming.HighContrast;

/// <summary>Helper text that is still readable at this weight.</summary>
public sealed class HighContrastCaption : ICaption
{
    public string Style => "high-contrast";
    public string Draw(string text) => ">> " + text.ToUpperInvariant();
}
