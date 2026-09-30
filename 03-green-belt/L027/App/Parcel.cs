namespace WhyWeTest.App;

/// <summary>
/// A parcel waiting for a price: how heavy it is, and whether the customer
/// asked for express delivery.
/// </summary>
public sealed record Parcel(int Grams, bool Express);
