namespace HowInheritanceWorks.Drills;

/// <summary>
/// The third derived class. It exists so the polymorphism demo has three
/// different answers rather than two, and so the calorie figures are not
/// suspiciously tidy.
/// </summary>
public class ConditioningDrill : Drill
{
    private readonly bool _weighted;

    public ConditioningDrill(string name, int minutes, bool weighted)
        : base(name, minutes)
    {
        _weighted = weighted;
    }

    public override string Describe()
        => $"{base.Describe()}{(_weighted ? ", weighted" : "")}";

    public override int CaloriesBurned() => Minutes * (_weighted ? 14 : 9);
}
