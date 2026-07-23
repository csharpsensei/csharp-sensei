services.AddScoped<IOrderValidator, NotEmptyValidator>();
services.AddScoped<IOrderValidator, StockValidator>();
services.AddScoped<IOrderValidator, FraudValidator>();

var one = provider.GetRequiredService<IOrderValidator>();

var all = provider.GetServices<IOrderValidator>();
