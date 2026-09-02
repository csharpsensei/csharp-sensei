namespace AbstractFactory.Theming.HighContrast;

/// <summary>A button with the same weight as the heading above it.</summary>
public sealed class HighContrastButton : IButton
{
    public string Style => "high-contrast";
    public string Draw(string label) => "### " + label.ToUpperInvariant() + " ###";
}
