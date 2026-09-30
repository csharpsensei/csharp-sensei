using ComponentTests.App.Pricing;

namespace ComponentTests.Tests.Unit;

/// <summary>
/// Unit tests: the discount on its own.
/// </summary>
[Trait("Kind", "Unit")]
public sealed class StudentDiscountTests
{
    [Fact]
    public void PercentOff_Student_GivesTwentyPercent()
    {
        // Arrange
        StudentDiscount discount = new();

        // Act
        int percentOff = discount.PercentOff(student: true);

        // Assert
        Assert.Equal(20, percentOff);
    }

    [Fact]
    public void PercentOff_NotAStudent_GivesNothing()
    {
        // Arrange
        StudentDiscount discount = new();

        // Act
        int percentOff = discount.PercentOff(student: false);

        // Assert
        Assert.Equal(0, percentOff);
    }
}
