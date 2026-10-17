using DecoratorPattern.Quotes;

namespace DecoratorPattern.Decorators;

/// <summary>
/// A decorator that tries again on a transient failure, up to a limit, and
/// then lets the failure through rather than hiding it.
/// </summary>
public sealed class RetryingQuote(IDeliveryQuote inner, int maxAttempts)
    : IDeliveryQuote
{
    public int Retries { get; private set; }

    public int DaysTo(string postcode)
    {
        for (int attempt = 1; ; attempt++)
        {
            try
            {
                return inner.DaysTo(postcode);
            }
            catch (TransientQuoteException) when (attempt < maxAttempts)
            {
                Retries++;
            }
        }
    }
}
