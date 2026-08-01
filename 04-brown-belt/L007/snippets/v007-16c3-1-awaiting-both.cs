string report = await api.GetReportAsync(1);

await SaveReportAsync(report);

int count = await CountRecordsAsync(api);

Console.WriteLine("records counted : " + count);
