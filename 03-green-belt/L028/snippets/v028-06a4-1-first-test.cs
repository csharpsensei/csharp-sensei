[Fact]
public void FeeInPence_ReturnedOnDueDate_ChargesNothing()
{
    // Arrange
    LateFeeCalculator calculator = new();
    DateOnly due = new(2026, 9, 1);

    // Act
    int fee = calculator.FeeInPence(due, due);

    // Assert
    Assert.Equal(0, fee);
}
