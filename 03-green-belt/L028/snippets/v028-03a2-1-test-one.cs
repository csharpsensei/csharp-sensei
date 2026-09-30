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
