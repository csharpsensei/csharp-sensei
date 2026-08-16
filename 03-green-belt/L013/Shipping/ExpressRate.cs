namespace OpenClosed.Shipping;

public class ExpressRate : IShippingRate
{
    private const decimal PerKilogram = 4.00m;
    private const decimal Handling = 3.00m;

    public string Carrier => "Express";

    public decimal PriceFor(Parcel parcel) => parcel.WeightKg * PerKilogram + Handling;
}
