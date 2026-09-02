public sealed class HighContrastHeading : IHeading
{
    public string Style => "high-contrast";
    public string Draw(string title) => "### " + title.ToUpperInvariant();
}

public sealed class HighContrastButton : IButton
{
    public string Style => "high-contrast";
    public string Draw(string label) => "### " + label.ToUpperInvariant() + " ###";
}

public sealed class HighContrastCaption : ICaption
{
    public string Style => "high-contrast";
    public string Draw(string text) => ">> " + text.ToUpperInvariant();
}
