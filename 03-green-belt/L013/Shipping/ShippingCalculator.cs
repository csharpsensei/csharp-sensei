namespace OpenClosed.Shipping;

/// <summary>
/// Closed for modification. Read the body of PriceFor and notice what is not
/// in it: no carrier name, no pricing rule, no switch. That is why adding,
/// removing or repricing a carrier never opens this file.
/// </summary>
public class ShippingCalculator
{
    private readonly IReadOnlyList<IShippingRate> _rates;

    public ShippingCalculator(IEnumerable<IShippingRate> rates)
    {
        _rates = rates.ToList();
    }

    public decimal PriceFor(Parcel parcel, string carrier)
    {
        IShippingRate? rate = _rates
            .SingleOrDefault(r => r.Carrier == carrier);

        if (rate is null)
        {
            throw new ArgumentException(
                $"No rate registered for carrier: {carrier}", nameof(carrier));
        }

        return rate.PriceFor(parcel);
    }
}
