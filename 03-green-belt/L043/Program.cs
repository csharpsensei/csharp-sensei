using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure;
using Shop.Orders;

var services = new ServiceCollection();
services.AddScoped<IOrderRepository, SqlOrderRepository>();
services.AddScoped<IEmailSender, SmtpEmailSender>();
services.AddScoped<OrderService>();

using var provider = services.BuildServiceProvider();
var service = provider.GetRequiredService<OrderService>();
service.PlaceOrder(new Order(1042, "ana@example.com", 59.90m));
