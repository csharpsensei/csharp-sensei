namespace DecoratorPattern.Quotes;

/// <summary>The one shape every courier quote and every wrapper shares.</summary>
public interface IDeliveryQuote
{
    int DaysTo(string postcode);
}
