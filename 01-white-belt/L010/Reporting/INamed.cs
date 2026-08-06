namespace Interfaces.Reporting;

/// <summary>
/// A second, unrelated contract — the point being that a class may implement as
/// many interfaces as it likes, while it gets exactly one base class.
/// </summary>
public interface INamed
{
    string Name { get; }
}
