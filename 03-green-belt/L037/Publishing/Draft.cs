namespace FacadePattern.Publishing;

/// <summary>An article ready to go out.</summary>
public sealed record Draft(string Slug, string Body, int Images);
