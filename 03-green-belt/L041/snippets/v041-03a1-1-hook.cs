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
