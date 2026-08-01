string report = api.GetReportAsync(1).Result;
api.GetReportAsync(1).Wait();

string report = await api.GetReportAsync(1);
