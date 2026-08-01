foreach (int id in reportIds)
{
    reports.Add(await api.GetReportAsync(id));
}

Task<string>[] pending = reportIds
    .Select(id => api.GetReportAsync(id))
    .ToArray();

string[] reports = await Task.WhenAll(pending);
