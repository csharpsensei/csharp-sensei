namespace WhyWeTest.App;

/// <summary>What a caller sends to ask for a price.</summary>
public sealed record QuoteRequest(int Grams, bool Express);
