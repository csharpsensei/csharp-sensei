namespace Microservices.Monolith;

/// <summary>One page, two modules, two ordinary method calls.</summary>
public sealed class ProductPage(CatalogModule catalog, StockModule stock)
{
    public string Describe(int productId) =>
        $"product {productId}: {catalog.NameOf(productId)}, "
        + $"{stock.LeftOf(productId)} left";
}
