using OpenClosed.Shipping;

namespace OpenClosed.Legacy;

/// <summary>
/// DO NOT COPY. This is the rejected shape the lesson opens with, kept
/// runnable so the video can show it working before it is replaced.
///
/// Every carrier's pricing rule lives inside one switch, in one method, in
/// one file. Adding a carrier means editing this method, and this method is
/// the one every existing carrier already runs through. Nothing here is
/// buggy. That is the point: the cost is not a defect, it is that the next
/// change has to land on top of code that is already correct.
///
/// This file is shown as it looks AFTER International was added, which is
/// the edit the lesson objects to. The earlier rungs (one carrier, then
/// three) are in snippets/ rather than here.
/// </summary>
public class ShippingCalculatorSwitch
{
    public decimal PriceFor(Parcel parcel, string carrier)
    {
        switch (carrier)
        {
            case "Standard":
                return parcel.WeightKg * 2.50m;

            case "Express":
                return parcel.WeightKg * 4.00m + 3.00m;

            case "Overnight":
                decimal flatFee = 12.00m;
                if (parcel.WeightKg <= 2.00m)
                {
                    return flatFee;
                }

                return flatFee + (parcel.WeightKg - 2.00m) * 6.50m;

            case "International":
                return parcel.WeightKg * 9.00m + 15.00m;

            default:
                // The trap. The compiler cannot help here: an unknown carrier
                // is only discovered when a real request runs this line.
                throw new ArgumentException(
                    $"Unknown carrier: {carrier}", nameof(carrier));
        }
    }
}
