namespace CoordinatingTasks.Taxis;

/// <summary>The same three firms every run. Bolt always answers first.</summary>
public static class Firms
{
    public static TaxiFirm[] ThreeOpen() =>
        new[]
        {
            new TaxiFirm("Acme", TimeSpan.FromMilliseconds(300)),
            new TaxiFirm("Bolt", TimeSpan.FromMilliseconds(100)),
            new TaxiFirm("City", TimeSpan.FromMilliseconds(200)),
        };

    public static TaxiFirm[] TwoClosed() =>
        new[]
        {
            new TaxiFirm("Acme", TimeSpan.FromMilliseconds(300), open: false),
            new TaxiFirm("Bolt", TimeSpan.FromMilliseconds(100)),
            new TaxiFirm("City", TimeSpan.FromMilliseconds(200), open: false),
        };
}
