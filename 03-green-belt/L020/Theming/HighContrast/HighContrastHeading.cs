namespace AbstractFactory.Theming.HighContrast;

/// <summary>Heavy rules and capitals, for readers who need the contrast.</summary>
public sealed class HighContrastHeading : IHeading
{
    public string Style => "high-contrast";
    public string Draw(string title) => "### " + title.ToUpperInvariant();
}
