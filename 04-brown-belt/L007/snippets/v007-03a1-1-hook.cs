foreach (int id in reportIds)
{
    string report = api.GetReportAsync(id).Result;
    reports.Add(report);
}
