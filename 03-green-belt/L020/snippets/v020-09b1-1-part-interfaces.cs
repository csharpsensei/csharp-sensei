public interface IHeading
{
    string Style { get; }
    string Draw(string title);
}

public interface IButton
{
    string Style { get; }
    string Draw(string label);
}

public interface ICaption
{
    string Style { get; }
    string Draw(string text);
}
