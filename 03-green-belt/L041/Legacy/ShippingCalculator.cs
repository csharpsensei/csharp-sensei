using CompositePattern.Packing;

namespace CompositePattern.Legacy;

/// <summary>
/// DO NOT COPY THIS SHAPE. Asks each thing what TYPE it is and handles the
/// types it knows, one level deep. A box inside a box is weighed as its
/// packaging alone. It is the hook of the lesson.
/// </summary>
public static class ShippingCalculator
{
    public static int Weigh(Box hamper)
    {
        int total = hamper.PackagingGrams;
        foreach (IPackable thing in hamper.Children)
        {
            if (thing is Item item)
                total += item.Grams();
            else if (thing is Box box)
                total += box.PackagingGrams;
        }

        return total;
    }
}
