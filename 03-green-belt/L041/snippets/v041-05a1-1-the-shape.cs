public interface IPackable
{
    string Name { get; }

    int Grams();

    IEnumerable<IPackable> Children { get; }
}
