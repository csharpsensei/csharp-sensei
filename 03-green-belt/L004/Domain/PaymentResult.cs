namespace DependencyInjection.Domain;

public sealed record PaymentResult(bool Succeeded, string Reason);