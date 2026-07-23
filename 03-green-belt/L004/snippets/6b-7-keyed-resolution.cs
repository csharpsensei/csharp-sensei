services.AddKeyedScoped<IPaymentGateway, StripeGateway>("stripe");
services.AddKeyedScoped<IPaymentGateway, PayPalGateway>("paypal");
services.AddKeyedScoped<IPaymentGateway, KlarnaGateway>("klarna");

var stripe = provider.GetRequiredKeyedService<IPaymentGateway>("stripe");

var maybe = provider.GetKeyedService<IPaymentGateway>("revolut");

var every = provider.GetKeyedServices<IPaymentGateway>(KeyedService.AnyKey);
