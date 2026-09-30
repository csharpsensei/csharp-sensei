namespace WhyWeTest.App;

/// <summary>A price that has been worked out and kept.</summary>
public sealed record Quote(Guid Id, int Grams, bool Express, int PriceInPence);
