static async void Handle(string report)
{
    await SaveReportAsync(report);
}

static async Task HandleAsync(string report)
{
    await SaveReportAsync(report);
}
