using WhyWeTest.App;

namespace WhyWeTest.Regression;

/// <summary>
/// DO NOT COPY THIS SHAPE. The calculator after a well meant tidy up: both
/// less-than-or-equals became less-than, because it looked neater. It
/// compiles, it reads fine, and a one kilo parcel now costs 550 pence instead
/// of 350. It sits beside the real calculator so the lesson can show the test
/// catching it without the repository's own tests going red.
/// </summary>
public sealed class TidiedPostageCalculator
{
    public int PriceInPence(Parcel parcel)
    {
        if (parcel.Grams <= 0 || parcel.Grams > PostageCalculator.MaxGrams)
        {
            throw new ArgumentOutOfRangeException(
                nameof(parcel), parcel.Grams, "A parcel weighs 1 to 5000 grams.");
        }

        int price = parcel.Grams < 1000 ? 350
                  : parcel.Grams < 2000 ? 550
                  : 850;

        return parcel.Express ? price + 250 : price;
    }
}
