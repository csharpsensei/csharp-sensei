namespace HowInheritanceWorks.Abstractions;

/// <summary>A second one, so the abstract method has something to vary.</summary>
public sealed class Squats : Exercise
{
    private readonly int _sets;

    public Squats(int sets) : base("Squats") => _sets = sets;

    public override int Repetitions() => _sets * 20;
}
