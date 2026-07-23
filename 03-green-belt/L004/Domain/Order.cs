namespace DependencyInjection.Domain;

public sealed record Order(
    int CustomerId,
    string CustomerEmail,
    decimal Total,
    string Method = "stripe",
    int Id = 1041);