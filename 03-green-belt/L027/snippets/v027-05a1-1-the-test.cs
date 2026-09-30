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
