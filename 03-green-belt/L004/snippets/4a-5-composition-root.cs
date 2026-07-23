var services = new ServiceCollection();

services.AddSingleton<IEmailSender, SmtpEmailSender>();
services.AddScoped<IOrderRepository, SqlOrderRepository>();
services.AddScoped<IPaymentGateway, StripePaymentGateway>();
services.AddScoped<OrderService>();

var provider = services.BuildServiceProvider();

using var scope = provider.CreateScope();
var orders = scope.ServiceProvider.GetRequiredService<OrderService>();
