public async ValueTask InitializeAsync()
{
    _app = RepairShopApi.Build("http://127.0.0.1:0");
    await _app.StartAsync();
    _client = new HttpClient { BaseAddress = new Uri(_app.Urls.First()) };
}

public async ValueTask DisposeAsync()
{
    _client?.Dispose();
    if (_app is not null)
    {
        await _app.StopAsync();
        await _app.DisposeAsync();
    }
}
