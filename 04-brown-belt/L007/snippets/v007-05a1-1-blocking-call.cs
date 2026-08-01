static string FetchReport(ReportApi api)
{
    string report = api.GetReportAsync(1).Result;
    return report;
}
