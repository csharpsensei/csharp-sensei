static async Task<string> FetchReportAsync(ReportApi api)
{
    string report = await api.GetReportAsync(1);
    return report;
}
