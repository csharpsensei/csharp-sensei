public class Basket
{
    private readonly List<Item> _items = new();

    public IReadOnlyList<Item> Items => _items;

    public void Add(Item item) => _items.Add(item);
}
