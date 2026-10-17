using System.Collections;
using GenericsFromScratch.Harvesting;

namespace GenericsFromScratch.Legacy;

/// <summary>
/// DO NOT COPY THIS SHAPE. Sums an ArrayList, which holds anything as object,
/// so the wrong thing is only found when the cast runs. The exception is
/// caught by name and reported, because the lesson is about where it happens.
/// </summary>
public static class UntypedHarvestLog
{
    public static HarvestReport TotalOf(ArrayList bag)
    {
        int total = 0;
        for (int i = 0; i < bag.Count; i++)
        {
            try
            {
                total += (int)bag[i]!;
            }
            catch (InvalidCastException)
            {
                return new HarvestReport(bag.Count, total,
                    "InvalidCastException at item " + (i + 1));
            }
        }

        return new HarvestReport(bag.Count, total, "nothing");
    }
}
