namespace UnitTestsInDepth.Regression;

/// <summary>
/// DO NOT COPY THIS SHAPE. A test with a name that says nothing, three
/// actions and three yes or no checks. It is the one test in this project
/// that is not Arrange, Act, Assert, on purpose, because it is the example of
/// what that shape prevents. Explicit, so a plain `dotnet run` skips it.
/// </summary>
public sealed class BadlyNamedTests
{
    [Fact(Explicit = true)]
    public void Test1()
    {
        BrokenLateFeeCalculator calculator = new();
        DateOnly due = new(2026, 9, 1);

        int onTime = calculator.FeeInPence(due, due);
        int oneDay = calculator.FeeInPence(due, due.AddDays(1));
        int month = calculator.FeeInPence(due, due.AddDays(30));

        Assert.True(onTime == 0);
        Assert.True(oneDay == 20);
        Assert.True(month == 500);
    }
}
