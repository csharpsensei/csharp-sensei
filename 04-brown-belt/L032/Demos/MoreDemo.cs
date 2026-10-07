using WhatsNew.Extensions;
using WhatsNew.Orders;

namespace WhatsNew.Demos;

public static class MoreDemo
{
    public static void Run()
    {
        Console.WriteLine("Closed hierarchies");
        OrderStatus[] statuses = [new Packed(), new Shipped(new DateOnly(2026, 11, 2))];
        foreach (OrderStatus status in statuses)
        {
            Console.WriteLine($"  {OrderMessages.Describe(status)}");
        }

        Console.WriteLine("Collection expression arguments");
        HashSet<string> tags = [with(StringComparer.OrdinalIgnoreCase), "Urgent", "URGENT", "urgent"];
        Console.WriteLine($"  tags kept: {tags.Count}");

        Console.WriteLine("Extension indexers");
        string[] customers = ["Ada", "Ben", "Cal", "Dee"];
        IEnumerable<string> waiting = customers.Where(name => name != "Ben");
        Console.WriteLine($"  second waiting: {waiting[1]}");

        Console.WriteLine("Labeled break");
        string[][] shelves = [["box", "box"], ["box", "parcel", "box"], ["box"]];
        string found = "not found";
        search: for (int row = 0; row < shelves.Length; row++)
        {
            for (int slot = 0; slot < shelves[row].Length; slot++)
            {
                if (shelves[row][slot] == "parcel")
                {
                    found = $"row {row}, slot {slot}";
                    break search;
                }
            }
        }

        Console.WriteLine($"  parcel at {found}");
    }
}
