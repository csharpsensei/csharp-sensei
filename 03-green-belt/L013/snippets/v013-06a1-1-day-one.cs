public class ShippingCalculator
{
    public decimal PriceFor(Parcel parcel)
    {
        return parcel.WeightKg * 2.50m;
    }
}
