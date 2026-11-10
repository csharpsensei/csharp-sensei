namespace Shop.Stock;

public class StockItem(string name)
{
    public event Action<string>? BackInStock;

    public int Count { get; private set; }

    public void Sell(int amount) => Count -= amount;

    public void Restock(int amount)
    {
        var wasEmpty = Count == 0;
        Count += amount;
        if (wasEmpty)
            BackInStock?.Invoke(name);
    }
}
