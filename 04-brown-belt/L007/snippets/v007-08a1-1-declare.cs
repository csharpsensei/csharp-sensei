ReportApi api = new ReportApi();

string report = api.GetReportAsync(1).Result;

Console.WriteLine(report.Length);
