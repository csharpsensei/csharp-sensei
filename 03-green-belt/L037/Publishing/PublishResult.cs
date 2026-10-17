namespace FacadePattern.Publishing;

/// <summary>What publishing did, in one line a caller can show.</summary>
public sealed record PublishResult(bool Published, string Summary);
