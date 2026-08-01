List<string> students = new List<string>();

students.Add("Aiko");
students.Add("Ben");
students.Add("Chidi");

foreach (string name in students)
{
    Console.WriteLine(name);
}

Console.WriteLine(students.Count);
