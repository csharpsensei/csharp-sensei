static async Task Main()
{
    ReportApi api = new ReportApi();

    string report = await FetchReportAsync(api);

    Console.WriteLine(report.Length);
}
