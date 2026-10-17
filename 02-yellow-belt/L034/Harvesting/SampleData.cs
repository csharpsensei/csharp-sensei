using System.Collections;

namespace GenericsFromScratch.Harvesting;

/// <summary>One allotment's week. Fixed values, so every run prints the same.</summary>
public static class SampleData
{
    public static ArrayList MixedBag()
    {
        var bag = new ArrayList();
        bag.Add(450);
        bag.Add(1000);
        bag.Add("12");
        bag.Add(300);
        return bag;
    }

    public static List<int> Weights() =>
        new List<int> { 450, 1000, 12, 300 };

    public static List<string> Crops() =>
        new List<string> { "leeks", "beans", "kale" };

    public static List<Harvest> Harvests() =>
        new List<Harvest>
        {
            new Harvest("Leeks", 450),
            new Harvest("Marrow", 2400),
            new Harvest("Beans", 1000),
        };
}
