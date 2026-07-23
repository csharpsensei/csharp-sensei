using DependencyInjection.Abstractions;
using DependencyInjection.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection;

// ── Section 1: the bad smell ─────────────────────────────────────────────────

public sealed class SmtpEmailSender : IEmailSender
{
    private readonly string _host;
    private readonly int _port;

    public SmtpEmailSender(string host, int port)
    {
        _host = host;
        _port = port;
    }

    // A stand-in, so the lesson stays offline and the output is identical on
    // every machine. The real implementation opens a socket on this line.
    public void Send(string to, string subject, string body) =>
        throw new NotSupportedException(
            $"a real SmtpClient would open a socket to {_host}:{_port} here");
}

public sealed class LegacyOrderService
{
    private readonly SmtpEmailSender _email = new("smtp.contoso.invalid", 587);

    public void PlaceOrder(Order order)
    {
        Console.WriteLine($"   Charging customer {order.CustomerId} {order.Total:C}...");
        _email.Send(order.CustomerEmail, "Order confirmed", $"Thanks for order {order.Id}.");
    }
}

// ── Section 2: the fix ───────────────────────────────────────────────────────

public sealed class OrderService
{
    private readonly IOrderRepository _repository;
    private readonly IEmailSender _email;
    private readonly IPaymentGateway _payments;

    public OrderService(
        IOrderRepository repository,
        IEmailSender email,
        IPaymentGateway payments)
    {
        _repository = repository;
        _email = email;
        _payments = payments;
    }

    public void PlaceOrder(Order order)
    {
        var result = _payments.Charge(order.CustomerId, order.Total);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException(result.Reason);
        }

        _repository.Save(order);
        _email.Send(order.CustomerEmail, "Order confirmed", $"Thanks for order {order.Id}.");
    }
}

public sealed class ConsoleEmailSender : IEmailSender
{
    public void Send(string to, string subject, string body) =>
        Console.WriteLine($"   [email] to={to} subject=\"{subject}\"");
}

public sealed class InMemoryOrderRepository : IOrderRepository
{
    public List<Order> Saved { get; } = new();
    public List<Invoice> Invoices { get; } = new();

    public void Save(Order order)
    {
        Saved.Add(order);
        Console.WriteLine($"   [repo]  saved order {order.Id}");
    }

    public void SaveInvoice(Invoice invoice) => Invoices.Add(invoice);
}

public sealed class AlwaysApprovesGateway : IPaymentGateway
{
    public PaymentResult Charge(int customerId, decimal amount) =>
        new(true, $"approved {amount:C}");
}

// ── Section 3: test doubles ──────────────────────────────────────────────────
//
// Both doubles are silent. A test double records; it does not narrate. Keeping
// them quiet is what lets section 3's output be nothing but assertions, which
// is the visible difference from section 2.

public sealed class FakeEmailSender : IEmailSender
{
    public List<(string To, string Subject)> Sent { get; } = new();

    public void Send(string to, string subject, string body) => Sent.Add((to, subject));
}

public sealed class FakeOrderRepository : IOrderRepository
{
    public List<Order> Saved { get; } = new();
    public List<Invoice> Invoices { get; } = new();

    public void Save(Order order) => Saved.Add(order);

    public void SaveInvoice(Invoice invoice) => Invoices.Add(invoice);
}

// ── Section 4: factory ───────────────────────────────────────────────────────

public sealed class StripeGateway : IPaymentGateway
{
    public PaymentResult Charge(int customerId, decimal amount) =>
        new(true, $"StripeGateway   charged {amount:C}");
}

public sealed class PayPalGateway : IPaymentGateway
{
    public PaymentResult Charge(int customerId, decimal amount) =>
        new(true, $"PayPalGateway   charged {amount:C}");
}

public sealed class KlarnaGateway : IPaymentGateway
{
    public PaymentResult Charge(int customerId, decimal amount) =>
        new(true, $"KlarnaGateway   charged {amount:C}");
}

// This factory takes IServiceProvider, which looks like the ServiceLocator in
// section 5 and is not the same thing. The difference is reach: this provider
// is a constructor parameter of one class with one job, and it is whatever
// scope resolved the factory. The section 5 locator is static, ambient, and
// callable from anywhere in the process.
//
// It must NOT be registered as a singleton. A singleton is resolved from the
// root scope, so its injected IServiceProvider is the root provider, and
// resolving a scoped gateway from root is a captive dependency the scope
// validator will reject. Register it scoped — see Program.cs.
public sealed class PaymentGatewayFactory : IPaymentGatewayFactory
{
    private readonly IServiceProvider _provider;

    public PaymentGatewayFactory(IServiceProvider provider) => _provider = provider;

    public IPaymentGateway Create(string method) => method switch
    {
        "stripe" => _provider.GetRequiredService<StripeGateway>(),
        "paypal" => _provider.GetRequiredService<PayPalGateway>(),
        "klarna" => _provider.GetRequiredService<KlarnaGateway>(),
        _ => throw new NotSupportedException($"Unknown method '{method}'.")
    };
}

public sealed class CheckoutService
{
    private readonly IPaymentGatewayFactory _gateways;

    public CheckoutService(IPaymentGatewayFactory gateways) => _gateways = gateways;

    public PaymentResult Pay(Order order)
    {
        var gateway = _gateways.Create(order.Method);
        return gateway.Charge(order.CustomerId, order.Total);
    }
}

// ── Section 5: the anti-pattern ──────────────────────────────────────────────

public static class ServiceLocator
{
    private static IServiceProvider? _provider;

    public static void Initialise(IServiceProvider provider) => _provider = provider;

    public static T Resolve<T>() where T : notnull =>
        (_provider ?? throw new InvalidOperationException("Locator not initialised."))
            .GetRequiredService<T>();
}

public sealed class InvoiceService
{
    public void Issue(Order order)
    {
        var repository = ServiceLocator.Resolve<IOrderRepository>();
        var email = ServiceLocator.Resolve<IEmailSender>();
        var pdf = ServiceLocator.Resolve<IPdfRenderer>();

        var invoice = pdf.Render(order);
        repository.SaveInvoice(invoice);
        email.Send(order.CustomerEmail, "Your invoice", invoice.Url);
    }
}

public sealed class HonestInvoiceService
{
    private readonly IOrderRepository _repository;
    private readonly IEmailSender _email;
    private readonly IPdfRenderer _pdf;

    public HonestInvoiceService(
        IOrderRepository repository, IEmailSender email, IPdfRenderer pdf)
    {
        _repository = repository;
        _email = email;
        _pdf = pdf;
    }

    public void Issue(Order order)
    {
        var invoice = _pdf.Render(order);

        _repository.SaveInvoice(invoice);
        _email.Send(order.CustomerEmail, "Your invoice", invoice.Url);
    }
}

// ── Lifetimes: three stamps, so you can see identity across scopes ───────────

public interface ISingletonStamp { string Id { get; } }
public interface IScopedStamp { string Id { get; } }
public interface ITransientStamp { string Id { get; } }

public sealed class SingletonStamp : ISingletonStamp
{
    public string Id { get; } = Guid.NewGuid().ToString()[..4];
}

public sealed class ScopedStamp : IScopedStamp
{
    public string Id { get; } = Guid.NewGuid().ToString()[..4];
}

public sealed class TransientStamp : ITransientStamp
{
    public string Id { get; } = Guid.NewGuid().ToString()[..4];
}

// ── Disposal: the container disposes what the container created ──────────────

public sealed class DisposableRepository : IDisposable
{
    private readonly string _label;

    public DisposableRepository(string label) => _label = label;

    public void Dispose() => Console.WriteLine($"   disposed: {_label}");
}

// ── Many implementations of one interface ───────────────────────────────────

public sealed record ValidationResult(bool IsValid, string Reason)
{
    public static ValidationResult Success { get; } = new(true, "ok");
}

public interface IOrderValidator
{
    string Name { get; }
    ValidationResult Validate(Order order);
}

public sealed class NotEmptyValidator : IOrderValidator
{
    public string Name => nameof(NotEmptyValidator);

    public ValidationResult Validate(Order order) =>
        order.Total > 0
            ? ValidationResult.Success
            : new ValidationResult(false, "order total is zero");
}

public sealed class StockValidator : IOrderValidator
{
    public string Name => nameof(StockValidator);

    public ValidationResult Validate(Order order) =>
        order.Id == 1052
            ? new ValidationResult(false, "SKU-3391 out of stock")
            : ValidationResult.Success;
}

public sealed class FraudValidator : IOrderValidator
{
    public string Name => nameof(FraudValidator);

    public ValidationResult Validate(Order order) =>
        order.Total < 10_000m
            ? ValidationResult.Success
            : new ValidationResult(false, "flagged for manual review");
}

public sealed class OrderValidationPipeline
{
    private readonly IEnumerable<IOrderValidator> _validators;

    public OrderValidationPipeline(IEnumerable<IOrderValidator> validators)
        => _validators = validators;

    public ValidationResult Validate(Order order)
    {
        foreach (var validator in _validators)
        {
            var result = validator.Validate(order);

            Console.WriteLine(
                $"   Order {order.Id}   {validator.Name,-20} {(result.IsValid ? "pass" : "FAIL   " + result.Reason)}");

            if (!result.IsValid)
                return result;
        }

        return ValidationResult.Success;
    }
}
