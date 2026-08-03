namespace HowInheritanceWorks.Drills;

/// <summary>
/// THE TRAP — kept runnable on purpose (demo 07) so the difference can be
/// watched rather than described. DO NOT COPY THIS SHAPE.
///
/// It is identical to <see cref="FormsDrill"/> except for one word: <c>new</c>
/// where the others say <c>override</c>.
///
/// <c>new</c> does not replace the base method. It HIDES it, and which one
/// runs is then decided by the type of the *variable*, not the type of the
/// *object*:
///
///     Drill       d = new HidingDrill(...);   d.Describe()  -> Drill's
///     HidingDrill h = new HidingDrill(...);   h.Describe()  -> this one
///
/// Same object. Two answers. That is not a rule anybody wants, and it is why
/// the compiler warns (CS0108) when you hide without saying so. `new` says "I
/// know, I meant it" — and it is almost never true.
/// </summary>
public class HidingDrill : Drill
{
    private readonly int _formCount;

    public HidingDrill(string name, int minutes, int formCount)
        : base(name, minutes)
    {
        _formCount = formCount;
    }

    // `new`, not `override`. This is the whole demo.
    public new string Describe()
        => $"{Name} — {_formCount} forms over {Minutes} minutes";
}
