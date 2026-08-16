public class StandardRate : IShippingRate
{
    private const decimal PerKilogram = 2.50m;

    public string Carrier => "Standard";

    public decimal PriceFor(Parcel parcel)
        => parcel.WeightKg * PerKilogram;
}
