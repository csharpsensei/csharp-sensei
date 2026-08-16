namespace OpenClosed.Shipping;

/// <summary>
/// The rule that used to be the first switch case. It did not change when it
/// moved. It just stopped sharing a file with two other carriers.
/// </summary>
public class StandardRate : IShippingRate
{
    private const decimal PerKilogram = 2.50m;

    public string Carrier => "Standard";

    public decimal PriceFor(Parcel parcel) => parcel.WeightKg * PerKilogram;
}
