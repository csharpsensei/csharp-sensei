using WhyWeTest.App;

namespace WhyWeTest.Regression;

/// <summary>
/// The same first unit test, pointed at the tidied calculator. Explicit, so a
/// plain `dotnet run` skips it and stays green. `dotnet run -- -explicit only`
/// runs it, and it fails, which is the whole point: this is the regression the
/// hook of the lesson shows being caught.
/// </summary>
public sealed class TidiedPostageTests
{
    [Fact(Explicit = true)]
    public void PriceInPence_OneKiloExactly_ChargesSmallParcelRate()
    {
        // Arrange
        TidiedPostageCalculator calculator = new();
        Parcel parcel = new(Grams: 1000, Express: false);

        // Act
        int price = calculator.PriceInPence(parcel);

        // Assert
        Assert.Equal(350, price);
    }
}
