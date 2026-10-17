namespace Microservices.Models;

/// <summary>What the stock service knows about a product.</summary>
public sealed record StockLevel(int ProductId, int Left);
