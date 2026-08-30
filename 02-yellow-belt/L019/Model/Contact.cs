namespace LinqBasics.Model;

/// <summary>
/// What the hiring manager actually asked for. Not a candidate: a name and a
/// number, and nothing else.
/// </summary>
public sealed record Contact(string Name, string Phone);
