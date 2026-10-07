extension(IEnumerable<string> sequence)
{
    public string this[int index] => sequence.ElementAt(index);
}

IEnumerable<string> waiting = customers.Where(name => name != "Ben");
Console.WriteLine($"  second waiting: {waiting[1]}");
