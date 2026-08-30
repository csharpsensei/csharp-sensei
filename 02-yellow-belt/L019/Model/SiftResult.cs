namespace LinqBasics.Model;

/// <summary>
/// What the hand written loop produces. Examined is carried because the loop is
/// the thing doing the walking, so the walking is a number it can report.
/// </summary>
public sealed record SiftResult(int Examined, IReadOnlyList<Candidate> Shortlisted);
