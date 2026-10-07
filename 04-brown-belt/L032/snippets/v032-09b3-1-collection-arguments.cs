HashSet<string> tags = [with(StringComparer.OrdinalIgnoreCase), "Urgent", "URGENT", "urgent"];
Console.WriteLine($"  tags kept: {tags.Count}");
