namespace WideEvents.Models;

/// <summary>What the caller sends to /checkout.</summary>
/// <param name="UserId">Opaque customer key. High cardinality — that is the point.</param>
/// <param name="Tier">free · business · enterprise. Low cardinality, good for grouping.</param>
/// <param name="Total">Cart value.</param>
/// <param name="Items">Number of lines in the cart.</param>
public record CheckoutRequest(
    string UserId,
    string Tier,
    decimal Total,
    int Items = 1);
