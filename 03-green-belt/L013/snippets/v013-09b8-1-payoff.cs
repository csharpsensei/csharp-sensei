// Shipping/InternationalRate.cs   the entire change
public class InternationalRate : IShippingRate
{
    public string Carrier => "International";

    public decimal PriceFor(Parcel parcel)
        => parcel.WeightKg * 9.00m + 15.00m;
}

// Program.cs, one line added:
    new InternationalRate(),
