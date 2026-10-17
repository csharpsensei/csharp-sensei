namespace DecoratorPattern.Quotes;

/// <summary>A failure worth trying again.</summary>
public sealed class TransientQuoteException(string postcode)
    : Exception("No answer yet for " + postcode);
