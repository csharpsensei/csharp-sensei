namespace Microservices.Monolith;

/// <summary>Stock, as a class inside the same app.</summary>
public sealed class StockModule
{
    public int LeftOf(int productId) => 4;
}
