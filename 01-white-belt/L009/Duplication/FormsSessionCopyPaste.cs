namespace HowInheritanceWorks.Duplication;

/// <summary>
/// THE BAD SMELL, half one — kept runnable on purpose (demo 01) so the two
/// shapes can be compared by running them. DO NOT COPY THIS SHAPE.
///
/// Read this class and <see cref="SparringSessionCopyPaste"/> side by side.
/// Name, Minutes, the constructor, the calorie rate and the cancellation rule
/// are the same in both, character for character. Only two lines differ.
///
/// The cost is not the typing. It is that <see cref="ShouldCancel"/> was fixed
/// here — a session with nobody in it should be cancelled, not one with fewer
/// than two — and the identical method next door still says <c>&lt; 2</c>. One
/// bug, fixed once, in one of the two places it lives.
/// </summary>
public class FormsSessionCopyPaste
{
    public string Name { get; }
    public int Minutes { get; }
    public int Attendees { get; }

    public FormsSessionCopyPaste(string name, int minutes, int attendees)
    {
        Name = name;
        Minutes = minutes;
        Attendees = attendees;
    }

    // FIXED HERE on the day somebody noticed. And nowhere else.
    public bool ShouldCancel() => Attendees < 1;

    public string Describe() => $"{Name} — {Minutes} minutes of forms";

    public int CaloriesBurned() => Minutes * 4;
}
