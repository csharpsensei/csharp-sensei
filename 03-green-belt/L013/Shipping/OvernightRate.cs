namespace OpenClosed.Shipping;

/// <summary>
/// The awkward one, and the reason the switch was getting hard to read: a
/// flat fee up to a weight band, then a rate per kilogram above it. Here it
/// is the only thing in the file, so the band can change without anyone
/// opening a file that prices a different carrier.
/// </summary>
public class OvernightRate : IShippingRate
{
    private const decimal FlatFee = 12.00m;
    private const decimal BandKilograms = 2.00m;
    private const decimal RatePerKilogram = 6.50m;

    public string Carrier => "Overnight";

    public decimal PriceFor(Parcel parcel)
    {
        if (parcel.WeightKg <= BandKilograms)
        {
            return FlatFee;
        }

        decimal excess = parcel.WeightKg - BandKilograms;
        return FlatFee + excess * RatePerKilogram;
    }
}
