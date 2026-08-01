string report = await Task.Run(() =>
    api.GetReportAsync(1).Result);
