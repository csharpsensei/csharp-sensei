namespace CompositePattern.Packing;

/// <summary>A leaf: one thing, its own weight, nothing inside it.</summary>
public sealed class Item(string name, int grams) : IPackable
{
    public string Name => name;

    public int Grams() => grams;

    public IEnumerable<IPackable> Children => Array.Empty<IPackable>();
}
