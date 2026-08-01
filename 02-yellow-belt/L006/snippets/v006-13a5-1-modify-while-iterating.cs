List<string> toRemove = new List<string>();

foreach (string name in students)
{
    if (name.StartsWith("A"))
    {
        toRemove.Add(name);
    }
}

foreach (string name in toRemove)
{
    students.Remove(name);
}
