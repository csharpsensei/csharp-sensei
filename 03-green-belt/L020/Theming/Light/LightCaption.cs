namespace AbstractFactory.Theming.Light;

/// <summary>Helper text in the default look: handed back as it was written.</summary>
public sealed class LightCaption : ICaption
{
    public string Style => "light";
    public string Draw(string text) => text;
}
