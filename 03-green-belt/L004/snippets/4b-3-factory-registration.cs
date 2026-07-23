services.AddScoped<StripeGateway>();
services.AddScoped<PayPalGateway>();
services.AddScoped<KlarnaGateway>();

services.AddSingleton<IPaymentGatewayFactory, PaymentGatewayFactory>();
services.AddScoped<CheckoutService>();
