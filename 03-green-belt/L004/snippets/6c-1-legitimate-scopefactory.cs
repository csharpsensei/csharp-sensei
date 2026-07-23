public sealed class OrderPollingService : BackgroundService
{
    private readonly IServiceScopeFactory _scopes;

    public OrderPollingService(IServiceScopeFactory scopes)
        => _scopes = scopes;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopes.CreateScope();
            var orders = scope.ServiceProvider.GetRequiredService<OrderService>();

            await orders.ProcessPendingAsync(stoppingToken);
            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
        }
    }
}
