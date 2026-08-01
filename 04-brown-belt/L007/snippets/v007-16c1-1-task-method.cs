static async Task SaveReportAsync(string report)
{
    await File.WriteAllTextAsync("report.json", report);
}
