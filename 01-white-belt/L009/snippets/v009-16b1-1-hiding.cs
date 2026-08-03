public class HidingDrill : Drill
{
    public new string Describe()      // new, not override
        => $"{Name} — {_formCount} forms";
}

// One word different from 13b2.
// It does something completely different.
