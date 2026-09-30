namespace ComponentTests.App.Pricing;

/// <summary>
/// Students get twenty percent off. Returns a percentage, not an amount of
/// money, which is exactly the kind of agreement two classes can get wrong.
/// </summary>
public sealed class StudentDiscount
{
    public const int StudentPercentOff = 20;

    public int PercentOff(bool student) => student ? StudentPercentOff : 0;
}
