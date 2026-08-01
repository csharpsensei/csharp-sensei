// V006 — Choosing the Right Collection
// Lists, Dictionaries and the Cost of Looking
// https://github.com/csharpsensei/csharp-sensei

// ---------------------------------------------------------------- PART ONE --
// A List grows and shrinks for you.

List<string> students = new List<string>();

students.Add("Aiko");
students.Add("Ben");
students.Add("Chidi");

foreach (string name in students)
{
    Console.WriteLine(name);
}

Console.WriteLine("Count: " + students.Count);
Console.WriteLine("First: " + students[0]);

students.Remove("Ben");

Console.WriteLine();
Console.WriteLine("after Remove(\"Ben\")");

foreach (string name in students)
{
    Console.WriteLine(name);
}

Console.WriteLine("Count: " + students.Count);
Console.WriteLine();

// ---------------------------------------------------------------- PART TWO --
// A List answers "what is in here, and in what order?".
// Finding one item by its id means walking the list.

Customer aiko = new Customer { Id = 1, Name = "Aiko" };
Customer ben = new Customer { Id = 2, Name = "Ben" };
Customer chidi = new Customer { Id = 3, Name = "Chidi" };

List<Customer> customers = new List<Customer>();
customers.Add(aiko);
customers.Add(ben);
customers.Add(chidi);

Customer? scanned = null;

foreach (Customer customer in customers)
{
    if (customer.Id == 2)
    {
        scanned = customer;
        break;
    }
}

Console.WriteLine("list scan for id 2 -> " + (scanned == null ? "null" : scanned.Name));
Console.WriteLine();

// ---------------------------------------------------------------- PART THREE --
// A Dictionary answers "what is filed under this label?" in one step.

Dictionary<int, Customer> customersById =
    new Dictionary<int, Customer>();

customersById[aiko.Id] = aiko;
customersById[ben.Id] = ben;
customersById[chidi.Id] = chidi;

Customer found = customersById[2];
Console.WriteLine("lookup 2         -> " + found.Name);

bool hit = customersById.TryGetValue(99, out Customer? missing);
Console.WriteLine("TryGetValue(99)  -> " + hit + ", customer is " +
                  (missing == null ? "null" : missing.Name));

Console.WriteLine();

foreach (KeyValuePair<int, Customer> pair in customersById)
{
    Console.WriteLine(pair.Key + " " + pair.Value.Name);
}

Console.WriteLine();

// ---------------------------------------------------------------- PART FOUR --
// The five mistakes.

// 1. A search inside a loop. Build the dictionary once, outside.
Dictionary<int, Customer> byId = new Dictionary<int, Customer>();

foreach (Customer customer in customers)
{
    byId[customer.Id] = customer;
}

// 2. The indexer throws on a missing key. TryGetValue does not.
try
{
    Customer boom = customersById[99];
    Console.WriteLine(boom.Name);
}
catch (KeyNotFoundException)
{
    Console.WriteLine("mistake 2: KeyNotFoundException for key 99");
}

// 3. Add refuses to overwrite; the indexer overwrites silently.
try
{
    customersById.Add(1, aiko);
}
catch (ArgumentException)
{
    Console.WriteLine("mistake 3: ArgumentException - key 1 is already present");
}

customersById[1] = aiko;
bool added = customersById.TryAdd(1, aiko);
Console.WriteLine("mistake 3: TryAdd on an existing key returned " + added);

// 4. Dictionary order is not a guarantee. Sort explicitly if you need order.
List<int> ordered = customersById.Keys.ToList();
ordered.Sort();
Console.WriteLine("mistake 4: sorted keys -> " + string.Join(", ", ordered));

// 5. Modifying a collection while iterating it throws.
List<string> roster = new List<string>();
roster.Add("Aiko");
roster.Add("Ben");
roster.Add("Chidi");

try
{
    foreach (string name in roster)
    {
        roster.Remove(name);
    }
}
catch (InvalidOperationException)
{
    Console.WriteLine("mistake 5: InvalidOperationException - collection was modified");
}

roster = new List<string>();
roster.Add("Aiko");
roster.Add("Ben");
roster.Add("Chidi");

List<string> toRemove = new List<string>();

foreach (string name in roster)
{
    if (name.StartsWith("A"))
    {
        toRemove.Add(name);
    }
}

foreach (string name in toRemove)
{
    roster.Remove(name);
}

Console.WriteLine("mistake 5: removed safely, count is now " + roster.Count);

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}
