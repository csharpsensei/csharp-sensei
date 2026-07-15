// MISTAKE 1: treating the blueprint like a house.
// Person.Name = "John";        // ❌ won't compile — the CLASS has no name
Person p = new Person();        // ✅ build the object first
p.Name = "John";                // ✅ then set ITS name

// MISTAKE 2: the everything-class.
public class Stuff              // ❌ what "one thing" is this? Nobody knows.
{
    public string PersonName { get; set; }
    public string ProductTitle { get; set; }
    public int OrderCount { get; set; }
}
// ✅ RULE: one class = one thing. Person. Product. Order. Split them.

















