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
