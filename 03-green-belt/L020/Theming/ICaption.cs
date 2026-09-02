namespace AbstractFactory.Theming;

/// <summary>The helper text under the button. Third member of the family.</summary>
public interface ICaption
{
    string Style { get; }
    string Draw(string text);
}
