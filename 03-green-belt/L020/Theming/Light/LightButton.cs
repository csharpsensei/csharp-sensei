namespace AbstractFactory.Theming.Light;

/// <summary>A button in the default look: square brackets, mixed case.</summary>
public sealed class LightButton : IButton
{
    public string Style => "light";
    public string Draw(string label) => "[ " + label + " ]";
}
