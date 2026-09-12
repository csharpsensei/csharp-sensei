namespace TailSampling.Checkout;

/// <summary>
/// One checkout this sample is going to run.
/// </summary>
/// <param name="Id">The order number. Stands in for a route parameter.</param>
/// <param name="Tier">"vip" or "standard". Nothing in the framework knows this.</param>
/// <param name="Failed">True if this checkout ends in a five hundred.</param>
/// <param name="Slow">True if this checkout takes real, measurable time.</param>
public sealed record Order(int Id, string Tier, bool Failed, bool Slow);
