ReportApi api = new ReportApi();

string report = await api.GetReportAsync(1);

Console.WriteLine(report.Length);
