var services = new ServiceCollection();

services.AddScoped<IOrderRepository, SqlOrderRepository>();
services.AddScoped<IEmailSender, SmtpEmailSender>();
services.AddScoped<InvoiceService>();

var provider = services.BuildServiceProvider(new ServiceProviderOptions
{
    ValidateOnBuild = true,
    ValidateScopes = true
});
