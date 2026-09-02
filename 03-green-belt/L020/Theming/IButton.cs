namespace AbstractFactory.Theming;

/// <summary>The button under the heading. Second member of the family.</summary>
public interface IButton
{
    string Style { get; }
    string Draw(string label);
}
