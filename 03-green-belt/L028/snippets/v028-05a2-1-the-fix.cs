public void FeeInPence_ThirtyDaysLate_CapsAtFivePounds()
{
    // Arrange
    BrokenLateFeeCalculator calculator = new();
    DateOnly due = new(2026, 9, 1);
    DateOnly returned = due.AddDays(30);

    // Act
    int fee = calculator.FeeInPence(due, returned);

    // Assert
    Assert.Equal(500, fee);
}
