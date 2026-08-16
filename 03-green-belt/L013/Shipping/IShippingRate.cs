namespace OpenClosed.Shipping;

/// <summary>
/// The seam. Two members and no more: which carrier this rate speaks for,
/// and what it charges for a parcel.
///
/// This interface is the complete list of what ShippingCalculator is allowed
/// to depend on. Anything else a carrier does (a weight band, a call to an
/// external API, a discount table) stays behind it, which is what lets a
/// carrier be added without opening the calculator.
/// </summary>
public interface IShippingRate
{
    string Carrier { get; }

    decimal PriceFor(Parcel parcel);
}
