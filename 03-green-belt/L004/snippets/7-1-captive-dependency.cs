services.AddSingleton<OrderCache>();
services.AddScoped<IOrderRepository, SqlOrderRepository>();

public sealed class OrderCache
{
    private readonly IOrderRepository _repository;

    public OrderCache(IOrderRepository repository)
        => _repository = repository;
}
