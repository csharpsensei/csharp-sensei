namespace OpenClosed.Shipping;

/// <summary>
/// The payoff, and the whole of it. This file is the entire "add a carrier"
/// change on the refactored side. Nothing in Shipping/ was opened to write
/// it: not ShippingCalculator, not StandardRate, not ExpressRate, not
/// OvernightRate. The only other line that moved is the one in Program.cs
/// that says this rate exists, and that line's job is to change.
/// </summary>
public class InternationalRate : IShippingRate
{
    private const decimal PerKilogram = 9.00m;
    private const decimal Customs = 15.00m;

    public string Carrier => "International";

    public decimal PriceFor(Parcel parcel) => parcel.WeightKg * PerKilogram + Customs;
}
