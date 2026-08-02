namespace WideEvents.Payments;

/// <summary>Outcome of a charge attempt.</summary>
/// <param name="Approved">Whether the gateway accepted the charge.</param>
/// <param name="Gateway">Which gateway handled it — a dimension worth grouping by.</param>
/// <param name="DeclineCode">Null when approved.</param>
/// <param name="Attempt">1-based; retries are worth knowing about.</param>
public record PaymentResult(
    bool Approved,
    string Gateway,
    string? DeclineCode,
    int Attempt);
