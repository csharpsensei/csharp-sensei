static async Task<int> CountRecordsAsync(ReportApi api)
{
    string report = await api.GetReportAsync(1);

    return CountRecords(report);
}
