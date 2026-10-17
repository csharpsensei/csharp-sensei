namespace GenericsFromScratch.Harvesting;

/// <summary>What the untyped total managed before it stopped.</summary>
public sealed record HarvestReport(int Packed, int TotalGrams, string Failure);
