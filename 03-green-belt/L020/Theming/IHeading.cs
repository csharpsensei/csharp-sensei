namespace AbstractFactory.Theming;

/// <summary>
/// The line across the top of a screen. One member of the theme family, and it
/// has to agree with the other two.
/// </summary>
public interface IHeading
{
    string Style { get; }
    string Draw(string title);
}
