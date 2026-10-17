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
