SaveReportAsync(report);
Console.WriteLine(File.ReadAllText("report.json"));

await SaveReportAsync(report);
Console.WriteLine("saved");
