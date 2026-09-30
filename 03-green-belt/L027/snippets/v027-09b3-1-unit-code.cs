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
