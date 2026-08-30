using LinqBasics.Model;

namespace LinqBasics.Legacy;

/// <summary>
/// The shortlist, written as a loop. Nothing here is wrong and nothing here is
/// slow. It is simply six lines of instructions wrapped around one line of
/// decision, and the reader has to separate the two by eye.
/// </summary>
public static class HandRolledSift
{
    public static SiftResult Run(IReadOnlyList<Candidate> pile)
    {
        List<Candidate> shortlisted = [];
        int examined = 0;

        foreach (Candidate candidate in pile)
        {
            examined++;

            if (candidate.Has("C#") && candidate.Has("Azure"))
            {
                shortlisted.Add(candidate);
            }
        }

        return new SiftResult(examined, shortlisted);
    }
}
