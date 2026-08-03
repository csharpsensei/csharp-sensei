namespace HowInheritanceWorks.Abstractions;

/// <summary>A concrete exercise. It must answer, so it does.</summary>
public sealed class PushUps : Exercise
{
    private readonly int _sets;

    public PushUps(int sets) : base("Push-ups") => _sets = sets;

    public override int Repetitions() => _sets * 15;
}
