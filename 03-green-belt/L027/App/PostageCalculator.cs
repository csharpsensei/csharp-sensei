namespace WhyWeTest.App;

/// <summary>
/// Prices a parcel in whole pence. Whole pence, so a price never depends on
/// the culture of the machine it is printed on.
/// </summary>
public sealed class PostageCalculator
{
    public const int MaxGrams = 5000;

    public int PriceInPence(Parcel parcel)
    {
        if (parcel.Grams <= 0 || parcel.Grams > MaxGrams)
        {
            throw new ArgumentOutOfRangeException(
                nameof(parcel), parcel.Grams, "A parcel weighs 1 to 5000 grams.");
        }

        int price = parcel.Grams <= 1000 ? 350
                  : parcel.Grams <= 2000 ? 550
                  : 850;

        return parcel.Express ? price + 250 : price;
    }
}
