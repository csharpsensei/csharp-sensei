public interface IScreenTheme
{
    string Style { get; }
    IHeading CreateHeading();
    IButton CreateButton();
    ICaption CreateCaption();
}
