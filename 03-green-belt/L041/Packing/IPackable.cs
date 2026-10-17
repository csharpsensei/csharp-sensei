namespace CompositePattern.Packing;

/// <summary>
/// The one shape a single item and a whole box share. Children is here so
/// anything can walk the tree without asking what it is holding; an item
/// simply has none.
/// </summary>
public interface IPackable
{
    string Name { get; }

    int Grams();

    IEnumerable<IPackable> Children { get; }
}
