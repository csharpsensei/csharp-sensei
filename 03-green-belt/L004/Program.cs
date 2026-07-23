using DependencyInjection;
using DependencyInjection.Abstractions;
using DependencyInjection.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// Guarantees the £ sign and the em dashes in the section rules render the same
// way on every machine, so the console-output still is reproducible.
Console.OutputEncoding = System.Text.Encoding.UTF8;

Section("1. THE BAD SMELL — a class that news up its own dependencies");

try
{
    var legacy = new LegacyOrderService();
    legacy.PlaceOrder(new Order(42, "kenji@example.com", 99.00m));
}
catch (NotSupportedException ex)
{
    Console.WriteLine($"   {ex.GetType().Name}: {ex.Message}");
    Console.WriteLine("   There is no seam here. A unit test cannot avoid the real SMTP server.");
}

Section("2. THE FIX — constructor injection and one composition root");

var services = new ServiceCollection();

services.AddSingleton<IEmailSender, ConsoleEmailSender>();
services.AddScoped<IOrderRepository, InMemoryOrderRepository>();
services.AddScoped<IPaymentGateway, AlwaysApprovesGateway>();
services.AddScoped<OrderService>();

services.AddScoped<StripeGateway>();
services.AddScoped<PayPalGateway>();
services.AddScoped<KlarnaGateway>();

// Scoped, not singleton. A singleton factory would be resolved from the root
// scope and would capture the ROOT provider, and resolving a scoped gateway
// from root is the captive-dependency error ValidateScopes exists to catch.
services.AddScoped<IPaymentGatewayFactory, PaymentGatewayFactory>();
services.AddScoped<CheckoutService>();

var provider = services.BuildServiceProvider(new ServiceProviderOptions
{
    ValidateOnBuild = true,
    ValidateScopes = true
});

using (var scope = provider.CreateScope())
{
    var orders = scope.ServiceProvider.GetRequiredService<OrderService>();
    orders.PlaceOrder(new Order(42, "kenji@example.com", 99.00m));
}

Section("3. TESTABILITY — the same class, composed by hand, no container");

var fakeEmail = new FakeEmailSender();
var repository = new FakeOrderRepository();
var underTest = new OrderService(repository, fakeEmail, new AlwaysApprovesGateway());

underTest.PlaceOrder(new Order(42, "kenji@example.com", 99.00m));

Console.WriteLine($"   Orders saved:    {repository.Saved.Count}");
Console.WriteLine($"   Emails sent:     {fakeEmail.Sent.Count}");
Console.WriteLine($"   First recipient: {fakeEmail.Sent[0].To}");

Section("4. FACTORY vs DI — when the choice depends on runtime data");

using (var scope = provider.CreateScope())
{
    var checkout = scope.ServiceProvider.GetRequiredService<CheckoutService>();

    foreach (var order in new[]
             {
                 new Order(42, "kenji@example.com", 99.00m, "stripe", 1041),
                 new Order(43, "mei@example.com", 24.50m, "paypal", 1042),
                 new Order(44, "sam@example.com", 310.00m, "klarna", 1043)
             })
    {
        var result = checkout.Pay(order);
        Console.WriteLine($"   Order {order.Id}  method={order.Method,-7} -> {result.Reason}");
    }
}

Section("5. SERVICE LOCATOR — the failure moves from startup to 02:14");

using (var scope = provider.CreateScope())
{
    ServiceLocator.Initialise(scope.ServiceProvider);

    try
    {
        new InvoiceService().Issue(new Order(42, "kenji@example.com", 99.00m));
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"   {ex.Message}");
        Console.WriteLine("   Nothing in InvoiceService's constructor warned you this could happen.");
    }
}

Console.WriteLine();
Console.WriteLine("   The same missing registration, declared honestly in a constructor:");

try
{
    var broken = new ServiceCollection();
    broken.AddScoped<HonestInvoiceService>();
    broken.BuildServiceProvider(new ServiceProviderOptions { ValidateOnBuild = true });
}
catch (AggregateException ex)
{
    Console.WriteLine($"   {ex.InnerException?.Message}");
    Console.WriteLine("   Caught at startup, in milliseconds, before a single order was touched.");
}

Section("6. LIFETIMES — singleton, scoped, transient");

var lifetimes = new ServiceCollection();
lifetimes.AddSingleton<ISingletonStamp, SingletonStamp>();
lifetimes.AddScoped<IScopedStamp, ScopedStamp>();
lifetimes.AddTransient<ITransientStamp, TransientStamp>();

var lifetimeProvider = lifetimes.BuildServiceProvider(new ServiceProviderOptions
{
    ValidateOnBuild = true,
    ValidateScopes = true
});

for (var i = 1; i <= 2; i++)
{
    using var scope = lifetimeProvider.CreateScope();
    Report(scope.ServiceProvider, $"   scope {i}");
    Report(scope.ServiceProvider, $"   scope {i}");
}

Console.WriteLine();
Console.WriteLine("   singleton: one forever. scoped: one per scope. transient: one per ask.");

Console.WriteLine();
Console.WriteLine("   Disposal — the container disposes what the container created:");

var disposal = new ServiceCollection();
disposal.AddScoped(_ => new DisposableRepository("scoped repository"));
var disposalProvider = disposal.BuildServiceProvider(new ServiceProviderOptions
{
    ValidateScopes = true
});

using (var scope = disposalProvider.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<DisposableRepository>();
}

Section("7. MANY IMPLEMENTATIONS — IEnumerable<T>, GetServices and TryAdd");

var many = new ServiceCollection();
many.AddScoped<IOrderValidator, NotEmptyValidator>();
many.AddScoped<IOrderValidator, StockValidator>();
many.AddScoped<IOrderValidator, FraudValidator>();
many.AddScoped<OrderValidationPipeline>();

many.TryAddEnumerable(
    ServiceDescriptor.Scoped<IOrderValidator, StockValidator>());

var manyProvider = many.BuildServiceProvider(new ServiceProviderOptions
{
    ValidateOnBuild = true,
    ValidateScopes = true
});

using (var scope = manyProvider.CreateScope())
{
    var pipeline = scope.ServiceProvider.GetRequiredService<OrderValidationPipeline>();

    var accepted = pipeline.Validate(new Order(42, "kenji@example.com", 99.00m, Id: 1051));
    Console.WriteLine($"   Order 1051   -> {(accepted.IsValid ? "accepted" : "rejected")}");

    Console.WriteLine();

    var rejected = pipeline.Validate(new Order(42, "kenji@example.com", 42.00m, Id: 1052));
    Console.WriteLine($"   Order 1052   -> {(rejected.IsValid ? "accepted" : "rejected")}");

    Console.WriteLine();

    var all = scope.ServiceProvider.GetServices<IOrderValidator>().ToList();
    var one = scope.ServiceProvider.GetRequiredService<IOrderValidator>();

    Console.WriteLine($"   GetServices<IOrderValidator>()      -> {all.Count} validators, in registration order");
    Console.WriteLine($"   GetRequiredService<IOrderValidator>() -> {one.Name}  (the LAST one registered)");
    Console.WriteLine("   TryAddEnumerable kept StockValidator from being registered twice.");
}

Console.WriteLine();
Console.WriteLine("Drill: find one class that calls new on a service, and move it to the constructor.");

static void Report(IServiceProvider sp, string label)
{
    var singleton = sp.GetRequiredService<ISingletonStamp>();
    var scoped = sp.GetRequiredService<IScopedStamp>();
    var first = sp.GetRequiredService<ITransientStamp>();
    var second = sp.GetRequiredService<ITransientStamp>();

    Console.WriteLine($"{label}  singleton={singleton.Id}  scoped={scoped.Id}  " +
                      $"transient={first.Id},{second.Id}");
}

static void Section(string title)
{
    Console.WriteLine();
    Console.WriteLine(new string('-', 78));
    Console.WriteLine(title);
    Console.WriteLine(new string('-', 78));
}
