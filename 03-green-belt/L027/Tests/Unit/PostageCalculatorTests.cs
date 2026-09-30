using WhyWeTest.App;

namespace WhyWeTest.Tests.Unit;

/// <summary>
/// Unit tests: the calculator on its own. No disk, no network, no server.
/// Every test is Arrange, Act, Assert, and every name says method, situation,
/// expected result, so a failure explains itself.
/// </summary>
[Trait("Kind", "Unit")]
public sealed class PostageCalculatorTests
{
    [Fact]
    public void PriceInPence_OneKiloExactly_ChargesSmallParcelRate()
    {
        // Arrange
        PostageCalculator calculator = new();
        Parcel parcel = new(Grams: 1000, Express: false);

        // Act
        int price = calculator.PriceInPence(parcel);

        // Assert
        Assert.Equal(350, price);
    }

    [Fact]
    public void PriceInPence_JustOverOneKilo_ChargesMediumParcelRate()
    {
        // Arrange
        PostageCalculator calculator = new();
        Parcel parcel = new(Grams: 1001, Express: false);

        // Act
        int price = calculator.PriceInPence(parcel);

        // Assert
        Assert.Equal(550, price);
    }

    [Fact]
    public void PriceInPence_TwoKilosExactly_ChargesMediumParcelRate()
    {
        // Arrange
        PostageCalculator calculator = new();
        Parcel parcel = new(Grams: 2000, Express: false);

        // Act
        int price = calculator.PriceInPence(parcel);

        // Assert
        Assert.Equal(550, price);
    }

    [Fact]
    public void PriceInPence_Express_AddsTwoHundredAndFiftyPence()
    {
        // Arrange
        PostageCalculator calculator = new();
        Parcel parcel = new(Grams: 1500, Express: true);

        // Act
        int price = calculator.PriceInPence(parcel);

        // Assert
        Assert.Equal(800, price);
    }

    [Fact]
    public void PriceInPence_OverFiveKilos_Throws()
    {
        // Arrange
        PostageCalculator calculator = new();
        Parcel parcel = new(Grams: 5001, Express: false);

        // Act
        Action act = () => calculator.PriceInPence(parcel);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void PriceInPence_ZeroGrams_Throws()
    {
        // Arrange
        PostageCalculator calculator = new();
        Parcel parcel = new(Grams: 0, Express: false);

        // Act
        Action act = () => calculator.PriceInPence(parcel);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }
}
