public class ShippingCalculator
{
    private readonly IReadOnlyList<IShippingRate> _rates;

    public decimal PriceFor(Parcel parcel, string carrier)
    {
        IShippingRate? rate = _rates
            .SingleOrDefault(r => r.Carrier == carrier);

        // ...guard omitted on screen, it is in the repo
        return rate.PriceFor(parcel);
    }
}
