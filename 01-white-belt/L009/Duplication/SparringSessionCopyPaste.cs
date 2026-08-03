namespace HowInheritanceWorks.Duplication;

/// <summary>
/// THE BAD SMELL, half two. DO NOT COPY THIS SHAPE.
///
/// The twin of <see cref="FormsSessionCopyPaste"/>, and the reason the lesson
/// starts here: the fix that went into that class never arrived in this one.
/// Nothing failed, nothing warned, and no test noticed, because from the
/// compiler's point of view these are two unrelated classes that happen to
/// look alike.
/// </summary>
public class SparringSessionCopyPaste
{
    public string Name { get; }
    public int Minutes { get; }
    public int Attendees { get; }

    public SparringSessionCopyPaste(string name, int minutes, int attendees)
    {
        Name = name;
        Minutes = minutes;
        Attendees = attendees;
    }

    // STILL WRONG. A session with one keen student gets cancelled on them.
    public bool ShouldCancel() => Attendees < 2;

    public string Describe() => $"{Name} — {Minutes} minutes of sparring";

    public int CaloriesBurned() => Minutes * 11;
}
