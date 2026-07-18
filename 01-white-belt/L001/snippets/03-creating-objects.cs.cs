// THE BUILDER: 'new' turns the blueprint into real objects.
Person john = new Person { Name = "John", Age = 30 };
Person sarah = new Person { Name = "Sarah", Age = 28 };

// THE DOT: reach inside an object.
Console.WriteLine(john.Name);   // John
Console.WriteLine(sarah.Age);   // 28

// Independent objects: changing one never touches the other.
sarah.Age = 29;
Console.WriteLine(john.Age);    // still 30











