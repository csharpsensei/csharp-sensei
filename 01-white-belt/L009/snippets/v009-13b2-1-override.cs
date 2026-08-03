public class FormsDrill : Drill
{
    public override string Describe()
        => $"{Name} — {_formCount} forms";
}

// override is not optional politeness.
// Leave it out and you get a different language
// feature, and a warning. See 16b1.
