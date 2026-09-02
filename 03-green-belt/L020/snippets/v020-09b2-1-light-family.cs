public sealed class LightHeading : IHeading
{
    public string Style => "light";
    public string Draw(string title) => "+-- " + title;
}

public sealed class LightButton : IButton
{
    public string Style => "light";
    public string Draw(string label) => "[ " + label + " ]";
}

public sealed class LightCaption : ICaption
{
    public string Style => "light";
    public string Draw(string text) => text;
}
