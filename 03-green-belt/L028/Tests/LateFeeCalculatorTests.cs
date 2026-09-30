using UnitTestsInDepth.App;

namespace UnitTestsInDepth.Tests;

/// <summary>
/// Unit tests for the late fee: the calculator on its own, nothing else.
/// Every test is Arrange, Act, Assert, one behaviour each, and every name is
/// method, scenario, expected result, so a failure explains itself.
/// </summary>
public sealed class LateFeeCalculatorTests
{
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

    [Fact]
    public void FeeInPence_ReturnedEarly_ChargesNothing()
    {
        // Arrange
        LateFeeCalculator calculator = new();
        DateOnly due = new(2026, 9, 1);
        DateOnly returned = due.AddDays(-3);

        // Act
        int fee = calculator.FeeInPence(due, returned);

        // Assert
        Assert.Equal(0, fee);
    }

    [Fact]
    public void FeeInPence_OneDayLate_ChargesTwentyPence()
    {
        // Arrange
        LateFeeCalculator calculator = new();
        DateOnly due = new(2026, 9, 1);
        DateOnly returned = due.AddDays(1);

        // Act
        int fee = calculator.FeeInPence(due, returned);

        // Assert
        Assert.Equal(20, fee);
    }

    [Fact]
    public void FeeInPence_TenDaysLate_ChargesTwoPounds()
    {
        // Arrange
        LateFeeCalculator calculator = new();
        DateOnly due = new(2026, 9, 1);
        DateOnly returned = due.AddDays(10);

        // Act
        int fee = calculator.FeeInPence(due, returned);

        // Assert
        Assert.Equal(200, fee);
    }

    [Fact]
    public void FeeInPence_TwentyFiveDaysLate_ChargesExactlyTheCap()
    {
        // Arrange
        LateFeeCalculator calculator = new();
        DateOnly due = new(2026, 9, 1);
        DateOnly returned = due.AddDays(25);

        // Act
        int fee = calculator.FeeInPence(due, returned);

        // Assert
        Assert.Equal(500, fee);
    }

    [Fact]
    public void FeeInPence_ThirtyDaysLate_CapsAtFivePounds()
    {
        // Arrange
        LateFeeCalculator calculator = new();
        DateOnly due = new(2026, 9, 1);
        DateOnly returned = due.AddDays(30);

        // Act
        int fee = calculator.FeeInPence(due, returned);

        // Assert
        Assert.Equal(500, fee);
    }
}
