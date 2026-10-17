namespace CompositePattern.Packing;

/// <summary>
/// The composite: a box is packable, and holds packables, which may be items
/// or more boxes. Its weight is its own packaging plus whatever it holds,
/// however deep that goes.
/// </summary>
public sealed class Box(string name, int packagingGrams) : IPackable
{
    private readonly List<IPackable> _contents = new List<IPackable>();

    public string Name => name;

    public int PackagingGrams => packagingGrams;

    public IEnumerable<IPackable> Children => _contents;

    public void Add(IPackable thing) => _contents.Add(thing);

    public int Grams() =>
        packagingGrams + _contents.Sum(thing => thing.Grams());
}
