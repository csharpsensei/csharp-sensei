namespace UnitTestsInDepth.Regression;

/// <summary>
/// DO NOT COPY THIS SHAPE. The well named test with the two values in
/// Assert.Equal the wrong way round, so the failure message reports them
/// backwards. The xUnit analyzer warns about it at build time, as xUnit2000,
/// and that warning is expected. Explicit, so a plain `dotnet run` skips it.
/// </summary>
public sealed class SwappedArgumentsTests
{
    [Fact(Explicit = true)]
    public void FeeInPence_ThirtyDaysLate_CapsAtFivePounds()
    {
        // Arrange
        BrokenLateFeeCalculator calculator = new();
        DateOnly due = new(2026, 9, 1);
        DateOnly returned = due.AddDays(30);

        // Act
        int fee = calculator.FeeInPence(due, returned);

        // Assert
        Assert.Equal(fee, 500);
    }
}
