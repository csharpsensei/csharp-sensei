// V001 — What is a Class? | C# Sensei | ⬜ White Belt
// youtube.com/@CSharpSensei

var john = new Person { Name = "John", Age = 30 };
var sarah = new Person { Name = "Sarah", Age = 28 };

Console.WriteLine($"{john.Name} is {john.Age}");
Console.WriteLine($"{sarah.Name} is {sarah.Age}");

sarah.Age = 29; // independent objects — John is untouched
Console.WriteLine($"After Sarah's birthday: {sarah.Name} is {sarah.Age}, {john.Name} is still {john.Age}");

public class Person
{
    public required string Name { get; set; }
    public int Age { get; set; }
}