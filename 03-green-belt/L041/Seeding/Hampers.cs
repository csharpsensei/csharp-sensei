using CompositePattern.Packing;

namespace CompositePattern.Seeding;

/// <summary>One hamper, built the same way every time, with a box inside it.</summary>
public static class Hampers
{
    public static Box Christmas()
    {
        var chocolates = new Box("Chocolate box", packagingGrams: 150);
        chocolates.Add(new Item("Truffles", 250));
        chocolates.Add(new Item("Fudge", 200));

        var hamper = new Box("Hamper", packagingGrams: 400);
        hamper.Add(new Item("Cheese", 500));
        hamper.Add(new Item("Wine", 1200));
        hamper.Add(chocolates);
        return hamper;
    }

    public static Box ChocolateBoxIn(Box hamper) =>
        hamper.Children.OfType<Box>().First(box => box.Name == "Chocolate box");
}
