public interface IShippingRate
{
    string Carrier { get; }

    decimal PriceFor(Parcel parcel);
}
