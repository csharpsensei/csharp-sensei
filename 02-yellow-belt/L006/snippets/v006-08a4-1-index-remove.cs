List<string> students = new List<string>();

students.Add("Aiko");
students.Add("Ben");
students.Add("Chidi");

Console.WriteLine(students[0]);

students.Insert(0, "Dara");
students.Remove("Ben");
students.RemoveAt(0);
