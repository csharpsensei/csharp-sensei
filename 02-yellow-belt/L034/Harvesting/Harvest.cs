namespace GenericsFromScratch.Harvesting;

/// <summary>One crop and its weight. Compares by weight, so it can be ranked.</summary>
public sealed record Harvest(string Crop, int Grams) : IComparable<Harvest>
{
    public int CompareTo(Harvest? other) =>
        other is null ? 1 : Grams.CompareTo(other.Grams);
}
