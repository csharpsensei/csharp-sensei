public sealed class BeltTestDrill : SparringDrill
{
    public sealed override string Describe()
        => $"{base.Describe()} — grading for {_belt}";
}

// Replace it, then close it. Nothing below may
// change it again.
// sealed is not about security. It is a statement:
// this behaviour is now decided.
