namespace AbstractFactory.Theming;

/// <summary>
/// The abstract factory. One create method per member of the family, so a
/// caller holding this cannot take a heading from one theme and a button from
/// another. The mismatch stops being a mistake anybody can make.
/// </summary>
public interface IScreenTheme
{
    string Style { get; }
    IHeading CreateHeading();
    IButton CreateButton();
    ICaption CreateCaption();
}
