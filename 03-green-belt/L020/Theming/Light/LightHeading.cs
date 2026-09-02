namespace AbstractFactory.Theming.Light;

/// <summary>A thin rule and the title as it was written.</summary>
public sealed class LightHeading : IHeading
{
    public string Style => "light";
    public string Draw(string title) => "+-- " + title;
}
