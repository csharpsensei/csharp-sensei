namespace UnitTestsInDepth.Regression;

/// <summary>
/// The same bug, caught by a test that checks one behaviour and is named for
/// it. Explicit, so a plain `dotnet run` skips it and stays green.
/// </summary>
public sealed class WellNamedTests
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
        Assert.Equal(500, fee);
    }
}
